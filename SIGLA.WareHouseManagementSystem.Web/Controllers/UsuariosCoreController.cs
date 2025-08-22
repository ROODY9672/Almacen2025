using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIGLA.Business.Dto.Helpers;
using SIGLA.Business.Dto.UsuariosFilessss;
using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Business.Dto.UsuarioSucursalsss;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.WareHouseManagementSystem.Web.HelpersEntity;
using System.Security.Claims;

namespace SIGLA.WareHouseManagementSystem.Web.Controllers
{
  


  public class UsuariosCoreController : Controller
  {
    private readonly ISucursalesFileService _sucursalesFileService;
    private readonly IUsuariosFileService _usuariosFileService;
    private readonly IUsuarioSucursalService _usuarioSucursalService;
    private readonly IUsuariosService _usuariosService;
    private readonly ISucursalesService _sucursalesService;

    public UsuariosCoreController(
      ISucursalesFileService sucursalesFileService,
      IUsuariosFileService usuariosFileService,
        IUsuarioSucursalService usuarioSucursalService,
        IUsuariosService usuariosService, ISucursalesService sucursalesService)
    {
      this._sucursalesFileService = sucursalesFileService;
      this._usuariosFileService = usuariosFileService;
      this._usuarioSucursalService = usuarioSucursalService;
      _usuariosService = usuariosService;
      _sucursalesService = sucursalesService;
    }






    [HttpGet]
    public async Task<ActionResult> Registrar()
    {

      // Obtener listado de tipo de descarga ordenado
      var listadoSucursales = await _sucursalesService.ListadoSucursalesComboBox();
      var listaOrdenadaSucursales = listadoSucursales.Data.OrderBy(tp => tp.NombreSucursal).ToList();
      ViewBag.viewSucursales = new SelectList(listaOrdenadaSucursales, "SucursalNo", "NombreSucursal");


      return View(new UsuariosCreacionDto());
    }



    [HttpPost]
    public async Task<JsonResult> Registrar(UsuariosCreacionDto dto, List<int> SucursalesSeleccionadas)
    {
      dto.UsuarioCreacion = "SYSADMIN";
      //dto.Rol = "Vendedor";
      dto.ClaveHash = HashHelper.ToSHA256(dto.Clave);

      var result = await _usuariosService.RegisterAsync(dto);

      if (result.Success)
      {
        // Ahora asignamos las sucursales al usuario
        int usuarioNo = result.Data;

        foreach (var sucursalNo in SucursalesSeleccionadas)
        {
          await _usuarioSucursalService.RegisterAsync(new UsuarioSucursalCreacionDto
          {
            UsuarioNo = usuarioNo,
            SucursalNo = sucursalNo,
            EsPrincipal = false,
            UsuarioCreacion = "SYSADMIN"
          });
        }

        return Json(new { success = true });
      }

      return Json(new { success = false, error = result.ErrorMessage });
    }




    [HttpGet]
    public async Task<ActionResult> RegistrarUsuariosNuevos()
    {
      var listadoSucursales = await _sucursalesService.ListadoSucursalesComboBox();
      var listaOrdenadaSucursales = listadoSucursales.Data
          .OrderBy(tp => tp.NombreSucursal)
          .ToList();

      var model = new UsuarioYImageViewModel
      {
        centroControl = new UsuariosCreacionDto(),
        Sucursales = listaOrdenadaSucursales
      };

      return View(model);
    }





    [HttpPost]
    public async Task<JsonResult> RegistrarUsuariosNuevos(
        UsuarioYImageViewModel visitasYImageViewModel,
        List<int> SucursalesSeleccionadas)
    {
      try
      {
        string usuarioNoActual = User.FindFirstValue(ClaimTypes.NameIdentifier);
        string nombreUsuario = User.Identity?.Name ?? "NO_DETECTADO";
        string correoUsuario = User.FindFirstValue(ClaimTypes.Email) ?? "NO_CORREO";



        // ✅ Validar si el correo ya existe
        bool correoExiste = await _usuariosService.CorreoExisteAsync(visitasYImageViewModel.centroControl.Correo);
        if (correoExiste)
        {
          return Json(new { success = false, error = "El correo ya se encuentra registrado." });
        }

        // ✅ Validar si el número de documento ya existe
        bool documentoExiste = await _usuariosService.DocumentoExisteAsync(visitasYImageViewModel.centroControl.NumeroDocumento);
        if (documentoExiste)
        {
          return Json(new { success = false, error = "El número de documento ya se encuentra registrado." });
        }








        visitasYImageViewModel.centroControl.UsuarioCreacion = correoUsuario;
        visitasYImageViewModel.centroControl.ClaveHash = HashHelper.ToSHA256(visitasYImageViewModel.centroControl.Clave);

        var result = await _usuariosService.RegisterUsuarioCompletoAsync(visitasYImageViewModel.centroControl);
        if (!result.Success)
          return Json(new { success = false, error = result.ErrorMessage });

        int usuarioNo = result.Data;

        if (SucursalesSeleccionadas != null && SucursalesSeleccionadas.Any())
        {
          foreach (var sucursalNo in SucursalesSeleccionadas)
          {
            await _usuarioSucursalService.RegisterAsync(new UsuarioSucursalCreacionDto
            {
              UsuarioNo = usuarioNo,
              SucursalNo = sucursalNo,
              EsPrincipal = false,
              UsuarioCreacion = correoUsuario
            });
          }
        }

        // Guardar imagen si fue cargada
        bool exitoImagenes = true;

        if (visitasYImageViewModel.fileInput != null && visitasYImageViewModel.fileInput.Any())
        {
          exitoImagenes = await GuardarImagenesUsuarioAsync(
              usuarioNo,
              visitasYImageViewModel.fileInput,
              visitasYImageViewModel.centroControl.UsuarioCreacion
          );
        }
        else
        {
          // ✅ Asignar imagen por defecto
          exitoImagenes = await AsignarImagenPorDefectoAsync(
              usuarioNo,
              visitasYImageViewModel.centroControl.Sexo,
              visitasYImageViewModel.centroControl.UsuarioCreacion
          );
        }

        if (!exitoImagenes)
        {
          return Json(new { success = false, error = "El usuario fue creado, pero ocurrió un error al guardar las imágenes." });
        }

        return Json(new { success = true });
      }
      catch (Exception ex)
      {
        return Json(new { success = false, error = "Error inesperado al registrar el usuario. Detalle técnico: " + ex.Message });
      }
    }




    private async Task<bool> AsignarImagenPorDefectoAsync(int usuarioNo, string genero, string usuarioCreacion)
    {
      try
      {
        string rutaRaiz = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "avatars");
        string archivoPorDefecto = genero.ToLower() == "masculino" ? "1.png" : "4.png";
        string rutaArchivo = Path.Combine(rutaRaiz, archivoPorDefecto);

        if (!System.IO.File.Exists(rutaArchivo))
          return false;

        byte[] imagenBytes = await System.IO.File.ReadAllBytesAsync(rutaArchivo);

        var imageUpload = new ImageViewModel();
        var imagenComprimida = imageUpload.CompressImage(imagenBytes);

        var modelFile = new UsuariosFileCreacionDto
        {
          UsuarioNo = usuarioNo,
          NombreDocumento = "FOTOS",
          FlagTipoFoto = "EVIDENCIA",
          NombreArchivo = archivoPorDefecto,
          ContentType = "image/png",
          Data = imagenComprimida,
          UsuarioCreacion = usuarioCreacion
        };

        var result = await _usuariosFileService.RegisterAsync(modelFile);
        return result.Success;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error al asignar imagen por defecto: {ex.Message}");
        return false;
      }
    }








    private async Task<bool> GuardarImagenesUsuarioAsync(int usuarioNo, IFormFile[] archivos, string usuarioCreacion)
    {
      if (archivos == null || archivos.Length == 0)
        return true; // No hay imágenes, se considera éxito

      var imageUpload = new ImageViewModel();

      foreach (var file in archivos)
      {
        try
        {
          if (file != null && file.Length > 0)
          {
            byte[] archivoBytes;

            using (var ms = new MemoryStream())
            {
              await file.CopyToAsync(ms);
              archivoBytes = ms.ToArray();
            }

            var imagenComprimida = imageUpload.CompressImage(archivoBytes);

            var modelFile = new UsuariosFileCreacionDto
            {
              UsuarioNo = usuarioNo,
              NombreDocumento = "FOTOS",
              FlagTipoFoto = "EVIDENCIA",
              NombreArchivo = file.FileName,
              ContentType = file.ContentType,
              Data = imagenComprimida,
              UsuarioCreacion = usuarioCreacion
            };

            var result = await _usuariosFileService.RegisterAsync(modelFile);
            if (!result.Success)
            {
              Console.WriteLine($"Error al registrar imagen: {result.ErrorMessage}");
              return false;
            }
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Excepción al guardar imagen {file?.FileName}: {ex.Message}");
          return false;
        }
      }

      return true;
    }


    public async Task<ActionResult> ListadoUsuariosSucursales()
    {


      var model = new UsuariosDto();

      // Obtener la fecha actual
      DateTime fechaActual = DateTime.Now;
      DateTime fechaDesde = fechaActual.AddMonths(-1);
      string fechaDesdeString = fechaDesde.ToString("yyyy-MM-dd");
      string fechaHastaString = fechaActual.ToString("yyyy-MM-dd");

      var data = await _usuariosService.ListadoUsuarios(fechaDesdeString, fechaHastaString);
      //var data = await _usuariosService.ListadoUsuariosConSucursale(fechaDesdeString, fechaHastaString);


      if (data.Data == null)
      {
        data.Data = new List<UsuariosColeccionDto>();
      }
      var datos = data.Data.ToList();

      //for (int i = 0; i < datos.Count; i++)
      //{
      //    datos[i].Numero = i + 1;
      //}

      model = new UsuariosDto
      {
        lstCentroControl = datos,
        FechaDesde = fechaDesdeString,
        FechaHasta = fechaHastaString,

      };

      return View(model);
    }



    [HttpPost]
    public async Task<ActionResult> ListadoUsuariosSucursales(UsuariosDto model)
    {

      var fechaDesde = (string.IsNullOrEmpty(model.FechaDesde)) ? null : Convert.ToDateTime(model.FechaDesde).ToString("yyyy-MM-dd");
      var fechaHasta = (string.IsNullOrEmpty(model.FechaHasta)) ? null : Convert.ToDateTime(model.FechaHasta).ToString("yyyy-MM-dd");

      var data = await _usuariosService.ListadoUsuarios(fechaDesde, fechaHasta);

      if (data.Data == null)
      {
        data.Data = new List<UsuariosColeccionDto>();
      }
      var datos = data.Data.ToList();


      var model2 = new UsuariosDto
      {
        //lstCentroControl = data.Data.ToList(),
        lstCentroControl = datos,
        FechaDesde = fechaDesde,
        FechaHasta = fechaHasta
      };
      return View(model2);
    }




    public async Task<JsonResult> GetDetalle(int id)
    {
      var detalle = await _usuariosService.ObtenerUsuariosConSucursalesXUsuarioNo(id);
      if (detalle == null || detalle.Data == null)
      {
        return Json(new { success = false, message = "No se encontró detalle para este registro." });
      }

      return Json(new { success = true, data = detalle.Data });
    }



    public async Task<ActionResult> GaleriaFotos(int id)
    {
      var data = await _usuariosFileService.ListadoFotosFiltradoTodos(id);
      return View(data.Data);
    }



    public async Task<ActionResult> EditarusuarioSucursal(int UsuarioNo)
    {
      var data = await _usuariosService.ObtenerporIdUsuarioNo(UsuarioNo);

      if (data.Data == null)
      {
        data.Data = new UsuarioObjetoDto();
      }

      var listadoSucursales = await _sucursalesService.ListadoSucursalesComboBox();
      var listaOrdenadaSucursales = listadoSucursales.Data
          .OrderBy(tp => tp.NombreSucursal)
          .ToList();

      // Obtener sucursales asignadas y filtrar solo los SucursalNo
      var sucursalesAsignadasResponse = await _usuarioSucursalService.ObtenerUsuariosConSucursalesXUsuarioNo(UsuarioNo);
      var sucursalesAsignadas = sucursalesAsignadasResponse.Data?
          .Select(x => x.SucursalNo)
          .ToList() ?? new List<int>(); // <- Evita null si no hay datos

      var model = new UsuariosViewModelEditar
      {
        centroControl = data.Data,
        Sucursales = listaOrdenadaSucursales,
        SucursalesAsignadas = sucursalesAsignadas
      };

      return View(model);
    }




    [HttpPost]
    public async Task<JsonResult> ActualizarUsuario(
       UsuarioYImageViewModel visitasYImageViewModel,
       List<int> SucursalesSeleccionadas)
    {
      try
      {
        string usuarioActual = User.Identity?.Name ?? "SYSADMIN";

        // Obtener el usuario original
        var usuarioExistente = await _usuariosService.ObtenerporIdUsuarioNo(visitasYImageViewModel.centroControl.UsuarioNo);

        if (usuarioExistente?.Data == null)
          return Json(new { success = false, error = "Usuario no encontrado." });


        // ✅ Validar correo SOLO si ha sido modificado
        if (!string.Equals(usuarioExistente.Data.Correo, visitasYImageViewModel.centroControl.Correo, StringComparison.OrdinalIgnoreCase))
        {
          bool correoExiste = await _usuariosService.CorreoExisteAsync(visitasYImageViewModel.centroControl.Correo);
          if (correoExiste)
            return Json(new { success = false, error = "El correo ya está registrado por otro usuario." });
        }

        // ✅ Validar número de documento SOLO si ha sido modificado
        if (!string.Equals(usuarioExistente.Data.NumeroDocumento, visitasYImageViewModel.centroControl.NumeroDocumento, StringComparison.OrdinalIgnoreCase))
        {
          bool documentoExiste = await _usuariosService.DocumentoExisteAsync(visitasYImageViewModel.centroControl.NumeroDocumento);
          if (documentoExiste)
            return Json(new { success = false, error = "El número de documento ya está registrado por otro usuario." });
        }



        // Asignar los nuevos valores
        var usuario = usuarioExistente.Data;
        usuario.NombreUsuario = visitasYImageViewModel.centroControl.NombreUsuario;
        usuario.ApellidoPaterno = visitasYImageViewModel.centroControl.ApellidoPaterno;
        usuario.ApellidoMaterno = visitasYImageViewModel.centroControl.ApellidoMaterno;
        usuario.NumeroDocumento = visitasYImageViewModel.centroControl.NumeroDocumento;
        usuario.Sexo = visitasYImageViewModel.centroControl.Sexo;
        usuario.Rol = visitasYImageViewModel.centroControl.Rol;

        // Actualizar en base de datos
        var resultado = await _usuariosService.UpdateUsuarioAsync(usuario);

        if (!resultado.Success)
          return Json(new { success = false, error = resultado.ErrorMessage });

        int usuarioNo = usuario.UsuarioNo;

        // 🔁 Eliminar todas las sucursales anteriores
        await _usuarioSucursalService.EliminarSucursalesPorUsuario(usuarioNo);

        // ✅ Insertar las nuevas
        if (SucursalesSeleccionadas != null && SucursalesSeleccionadas.Any())
        {
          foreach (var sucursalNo in SucursalesSeleccionadas)
          {
            await _usuarioSucursalService.RegisterAsync(new UsuarioSucursalCreacionDto
            {
              UsuarioNo = usuarioNo,
              SucursalNo = sucursalNo,
              EsPrincipal = false,
              UsuarioCreacion = usuarioActual
            });
          }
        }

        // 📷 Si se subió una nueva imagen
        if (visitasYImageViewModel.fileInput != null && visitasYImageViewModel.fileInput.Any())
        {
          var exitoImagen = await GuardarImagenesUsuarioAsync(
              usuarioNo,
              visitasYImageViewModel.fileInput,
              usuarioActual
          );

          if (!exitoImagen)
          {
            return Json(new { success = false, error = "Usuario actualizado, pero error al guardar imagen." });
          }
        }

        return Json(new { success = true });
      }
      catch (Exception ex)
      {
        return Json(new { success = false, error = "Error inesperado: " + ex.Message });
      }
    }









    [HttpPost]
    public async Task<JsonResult> EliminarUsuario(int usuarioNo)
    {
      try
      {
        // 🔍 Verificar si el usuario existe
        var usuario = await _usuariosService.ObtenerporIdUsuarioNo(usuarioNo);
        if (usuario?.Data == null)
          return Json(new { success = false, error = "El usuario no existe." });

        // 🔍 Verificar si tiene sucursales asociadas
        var sucursales = await _usuarioSucursalService.ObtenerUsuariosConSucursalesXUsuarioNo(usuarioNo);
        if (sucursales?.Data != null && sucursales.Data.Any())
        {
          // 🔁 Eliminar relaciones con sucursales
          var eliminarSucursales = await _usuarioSucursalService.EliminarSucursalesPorUsuario(usuarioNo);
          if (!eliminarSucursales.Success)
            return Json(new { success = false, error = "No se pudieron eliminar las sucursales del usuario." });
        }

        // ❌ Luego eliminar el usuario
        var eliminarUsuario = await _usuariosService.EliminarUsuarioAsync(usuarioNo);
        if (!eliminarUsuario.Success)
          return Json(new { success = false, error = eliminarUsuario.ErrorMessage });

        return Json(new { success = true });
      }
      catch (Exception ex)
      {
        return Json(new { success = false, error = "Error al eliminar el usuario: " + ex.Message });
      }
    }




    [HttpGet]
    public async Task<FileResult> ObtenerFotoPerfil(int usuarioNo)
    {
      var resultado = await _usuariosFileService.ObtenerFotoPerfilAsync(usuarioNo);

      if (resultado?.Data == null)
      {
        // Imagen por defecto si no tiene foto
        string rutaDefault = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "avatars", "1.png");
        byte[] bytes = await System.IO.File.ReadAllBytesAsync(rutaDefault);
        return File(bytes, "image/png");
      }

      return File(resultado.Data.Data, resultado.Data.ContentType ?? "image/png");
    }












    public async Task<ActionResult> UsuarioSucursalAsignado()
    {
      // ✅ 1. Obtener el UsuarioNo desde el Claim
      string usuarioNoStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (!int.TryParse(usuarioNoStr, out int usuarioNo))
      {
        return RedirectToAction("LoginBasic", "Auth"); // o a una vista de error
      }



      // ✅ 2. Obtener información del usuario
      var data = await _usuariosService.ObtenerporIdUsuarioNo(usuarioNo);
      if (data.Data == null)
      {
        data.Data = new UsuarioObjetoDto();
      }

      // ✅ 3. Obtener sucursales asignadas al usuario
      var sucursalesAsignadasResponse = await _usuarioSucursalService.ObtenerUsuariosConSucursalesXUsuarioNoDetalle(usuarioNo);
      //var listadoSucursales = sucursalesAsignadasResponse.Data?.ToList()
      //                       ?? new List<UsuarioSucursalColeccionDto>();


      // Ordenar colocando primero la sucursal principal
      var listadoSucursales = sucursalesAsignadasResponse.Data?
          .OrderByDescending(x => x.SUCURSALES_Sede == "Principal") // o x.EsPrincipal si es bool
          .ToList()
          ?? new List<UsuarioSucursalColeccionDto>();

      // ✅ 4. Preparar modelo
      var model = new UsuariosPanelControlViewModel
      {
        centroControl = data.Data,
        Sucursales = listadoSucursales
      };

      return View(model);
    }












    [HttpGet]
    public async Task<FileResult> ObtenerFotoSucursal(int sucursalNo)
    {
      var resultado = await _sucursalesFileService.ListadoFotosFiltradoTodos(sucursalNo);

      // Si no hay resultados o la colección está vacía
      var foto = resultado?.Data?.FirstOrDefault();
      if (foto?.Data == null)
      {
        string rutaDefault = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "avatars", "default-sucursal.png");
        byte[] bytes = await System.IO.File.ReadAllBytesAsync(rutaDefault);
        return File(bytes, "image/png");
      }

      return File(foto.Data, foto.ContentType ?? "image/png");
    }






    public IActionResult SeleccionarSucursal(int sucursalNo, int usuarioSucursalNo, int usuarioNo,
         string empresaSucursal, string direccion, string sede,
         string razonSocial, string ruc, string telefono1,
         string telefono2, string correo)
    {
      HttpContext.Session.SetInt32("SucursalSeleccionada", sucursalNo);
      HttpContext.Session.SetInt32("UsuarioSucursalSeleccionado", usuarioSucursalNo);
      HttpContext.Session.SetInt32("UsuarioNo", usuarioNo);

      // Validación: si sede == "1" guardar "Principal", si no "Sucursal"
      //string sedeFormateada = sede == "1" ? "Principal" : "Sucursal";
      //HttpContext.Session.SetString("Sede", sedeFormateada);
      HttpContext.Session.SetString("Sede", sede);

      HttpContext.Session.SetString("Direccion", direccion);
      HttpContext.Session.SetString("Sucursal", empresaSucursal);

      // Nuevas variables de empresa
      HttpContext.Session.SetString("EmpresaRazonSocial", razonSocial);
      HttpContext.Session.SetString("EmpresaRUC", ruc);
      HttpContext.Session.SetString("EmpresaTelefono1", telefono1);
      HttpContext.Session.SetString("EmpresaTelefono2", telefono2);
      HttpContext.Session.SetString("EmpresaCorreo", correo);

      return RedirectToAction("Index", "Ventas"); // o Ventas, según el flujo deseado
    }



    public IActionResult ReiniciarSucursal()
    {
      HttpContext.Session.Remove("SucursalSeleccionada");
      HttpContext.Session.Remove("UsuarioSucursalSeleccionado");
      return RedirectToAction("UsuarioSucursalAsignado");
    }





  }

}
