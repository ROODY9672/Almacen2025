using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIGLA.Business.Dto.SucursalesFilesss;
using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Business.Dto.UsuariosFilessss;
using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Business.Dto.UsuarioSucursalsss;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Business.Services.Wrapper.Service;
using SIGLA.Entity.DataBase.Empresa;
using SIGLA.Entity.DataBase.Sucursales;
using SIGLA.WareHouseManagementSystem.Web.HelpersEntity;
using System.Security.Claims;

namespace SIGLA.WareHouseManagementSystem.Web.Controllers
{
  [LoginRequired]
  public class SucursalesController : Controller
  {
    private readonly IEmpresaService _empresaService;
    private readonly ISucursalesFileService _sucursalesFileService;
    private readonly ISucursalesService _sucursalesService;

    public SucursalesController(
      IEmpresaService empresaService,
      ISucursalesFileService sucursalesFileService,
      ISucursalesService sucursalesService)
    {
      this._empresaService = empresaService;
      this._sucursalesFileService = sucursalesFileService;
      this._sucursalesService = sucursalesService;
    }



    

    [HttpGet]
    public async Task<ActionResult> RegistrarSucursal()
    {
      var empresaResponse = await _empresaService.ObtenerEmpresaObjetoDto();
      var empresa = empresaResponse.Data;

      var model = new SucursalYImageViewModel
      {
        centroControl = new SucursalesCreacionDto(),
        RazonSocial = empresa?.RazonSocial,
        NumRuc = empresa?.NumRuc,
        EmpresaNo = empresa.EmpresaNo,
        
      };

      return View(model);
    }







    [HttpPost]
    public async Task<JsonResult> RegistrarSucursal(
    SucursalYImageViewModel visitasYImageViewModel  )
    {
      try
      {
        string usuarioNoActual = User.FindFirstValue(ClaimTypes.NameIdentifier);
        string nombreUsuario = User.Identity?.Name ?? "NO_DETECTADO";
        string correoUsuario = User.FindFirstValue(ClaimTypes.Email) ?? "NO_CORREO";



        //// ✅ Validar si el correo ya existe
        //bool correoExiste = await _usuariosService.CorreoExisteAsync(visitasYImageViewModel.centroControl.Correo);
        //if (correoExiste)
        //{
        //  return Json(new { success = false, error = "El correo ya se encuentra registrado." });
        //}


        visitasYImageViewModel.centroControl.UsuarioCreacion = correoUsuario;
      
        var result = await _sucursalesService.RegisterAsync(visitasYImageViewModel.centroControl);
        if (!result.Success)
          return Json(new { success = false, error = result.ErrorMessage });

        int sucursalNo = result.Data;

        

        // Guardar imagen si fue cargada
        bool exitoImagenes = true;

        if (visitasYImageViewModel.fileInput != null && visitasYImageViewModel.fileInput.Any())
        {
          exitoImagenes = await GuardarImagenesUsuarioAsync(
              sucursalNo,
              visitasYImageViewModel.fileInput,
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







    private async Task<bool> GuardarImagenesUsuarioAsync(int sucursalNo, IFormFile[] archivos, string usuarioCreacion)
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

            var modelFile = new SucursalesFileCreacionDto
            {
              SucursalNo = sucursalNo,
              NombreDocumento = "FOTOS",
              FlagTipoFoto = "EVIDENCIA",
              NombreArchivo = file.FileName,
              ContentType = file.ContentType,
              Data = imagenComprimida,
              UsuarioCreacion = usuarioCreacion
            };

            var result = await _sucursalesFileService.RegisterAsync(modelFile);
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







    public async Task<ActionResult> ListadoEmpresaSucursales()
    {


      var model = new SucursalesDto();

      // Obtener la fecha actual
      DateTime fechaActual = DateTime.Now;
      DateTime fechaDesde = fechaActual.AddMonths(-1);
      string fechaDesdeString = fechaDesde.ToString("yyyy-MM-dd");
      string fechaHastaString = fechaActual.ToString("yyyy-MM-dd");

      var data = await _sucursalesService.ListadoSucursales(fechaDesdeString, fechaHastaString);
      //var data = await _usuariosService.ListadoUsuariosConSucursale(fechaDesdeString, fechaHastaString);


      if (data.Data == null)
      {
        data.Data = new List<SucursalesColeccionDto>();
      }
      var datos = data.Data.ToList();

      //for (int i = 0; i < datos.Count; i++)
      //{
      //    datos[i].Numero = i + 1;
      //}

      model = new SucursalesDto
      {
        lstCentroControl = datos,
        FechaDesde = fechaDesdeString,
        FechaHasta = fechaHastaString,

      };

      return View(model);
    }



    [HttpPost]
    public async Task<ActionResult> ListadoEmpresaSucursales(SucursalesDto model)
    {

      var fechaDesde = (string.IsNullOrEmpty(model.FechaDesde)) ? null : Convert.ToDateTime(model.FechaDesde).ToString("yyyy-MM-dd");
      var fechaHasta = (string.IsNullOrEmpty(model.FechaHasta)) ? null : Convert.ToDateTime(model.FechaHasta).ToString("yyyy-MM-dd");

      var data = await _sucursalesService.ListadoSucursales(fechaDesde, fechaHasta);

      if (data.Data == null)
      {
        data.Data = new List<SucursalesColeccionDto>();
      }
      var datos = data.Data.ToList();


      var model2 = new SucursalesDto
      {
        //lstCentroControl = data.Data.ToList(),
        lstCentroControl = datos,
        FechaDesde = fechaDesde,
        FechaHasta = fechaHasta
      };
      return View(model2);
    }






    [HttpGet]
    public async Task<FileResult> ObtenerFotoPerfilSucursal(int usuarioNo)
    {
      //var resultado = await _usuariosFileService.ObtenerFotoPerfilAsync(usuarioNo);

      //if (resultado?.Data == null)
      //{
        // Imagen por defecto si no tiene foto
        string rutaDefault = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "avatars", "manzana.png");
        byte[] bytes = await System.IO.File.ReadAllBytesAsync(rutaDefault);
        return File(bytes, "image/png");
      //}

      //return File(resultado.Data.Data, resultado.Data.ContentType ?? "image/png");
    }




    public async Task<ActionResult> GaleriaFotos(int id)
    {
      var data = await _sucursalesFileService.ListadoFotosFiltradoTodos(id);
      return View(data.Data);
    }








    public async Task<ActionResult> EditarSucursal(int SucursalNo)
    {
      var data = await _sucursalesService.ObtenerporIdSucursalNo(SucursalNo);

      if (data.Data == null)
      {
        data.Data = new SucursalesObjetoDto();
      }
     
      var model = new SucursalesViewModelEditar
      {
        centroControl = data.Data 
      };

      return View(model);
    }









    [HttpPost]
    public async Task<JsonResult> ActualizarUsuario(
      SucursalesViewModelEditar visitasYImageViewModel )
    {
      try
      {
        string usuarioActual = User.Identity?.Name ?? "SYSADMIN";

        // Obtener el usuario original
        var usuarioExistente = await _sucursalesService.ObtenerporIdSucursalNo(visitasYImageViewModel.centroControl.SucursalNo);

        if (usuarioExistente?.Data == null)
          return Json(new { success = false, error = "Usuario no encontrado." });


        // ✅ Validar correo SOLO si ha sido modificado
        //if (!string.Equals(usuarioExistente.Data.Correo, visitasYImageViewModel.centroControl.Correo, StringComparison.OrdinalIgnoreCase))
        //{
        //  bool correoExiste = await _usuariosService.CorreoExisteAsync(visitasYImageViewModel.centroControl.Correo);
        //  if (correoExiste)
        //    return Json(new { success = false, error = "El correo ya está registrado por otro usuario." });
        //}

      



        // Asignar los nuevos valores
        var usuario = usuarioExistente.Data;
        
        usuario.SucursalNo = visitasYImageViewModel.centroControl.SucursalNo;
        usuario.NombreSucursal = visitasYImageViewModel.centroControl.NombreSucursal;
        usuario.Direccion = visitasYImageViewModel.centroControl.Direccion;
        usuario.Telefono = visitasYImageViewModel.centroControl.Telefono;
        usuario.Correo = visitasYImageViewModel.centroControl.Correo;
        usuario.EmpresaNo = visitasYImageViewModel.centroControl.EmpresaNo;


        // Actualizar en base de datos
        var resultado = await _sucursalesService.UpdateSucursalesAsync(usuario);

        if (!resultado.Success)
          return Json(new { success = false, error = resultado.ErrorMessage });

        int sucursalNo = usuario.SucursalNo;

       
       
        // 📷 Si se subió una nueva imagen
        if (visitasYImageViewModel.fileInput != null && visitasYImageViewModel.fileInput.Any())
        {
          var exitoImagen = await GuardarImagenesUsuarioAsync(
              sucursalNo,
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









    public IActionResult Index()
    {
      return View();
    }
  }
}
