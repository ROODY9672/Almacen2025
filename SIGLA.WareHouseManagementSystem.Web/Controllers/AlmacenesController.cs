using Microsoft.AspNetCore.Mvc;
using SIGLA.Business.Dto.AlmacenesFilesss;
using SIGLA.Business.Dto.Almacenessss;
using SIGLA.Business.Dto.SucursalesFilesss;
using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Business.Services.Wrapper.Service;
using SIGLA.Entity.DataBase.Sucursales;
using SIGLA.WareHouseManagementSystem.Web.HelpersEntity;
using System.Security.Claims;

namespace SIGLA.WareHouseManagementSystem.Web.Controllers
{
  public class AlmacenesController : Controller
  {
    private readonly IAlmacenesService _almacenesService;
    private readonly IAlmacenesFileService _almacenesFileService;

    public AlmacenesController(IAlmacenesService almacenesService, IAlmacenesFileService almacenesFileService )
    {
      this._almacenesService = almacenesService;
      this._almacenesFileService = almacenesFileService;
    }







    [HttpGet]
    public async Task<ActionResult> RegistrarAlmacenes()
    {

      var model = new AlmacenesYImageViewModel
      {
        centroControl = new AlmacenesCreacionDto(),
       

      };

      return View(model);
    }




 
 
    [HttpPost]
    public async Task<JsonResult> RegistrarAlmacenes(AlmacenesYImageViewModel model)
    {
      try
      {
        // Obtener datos del usuario logueado
        string correoUsuario = User.FindFirstValue(ClaimTypes.Email) ?? "NO_CORREO";

        // Obtener datos de sesión
        var usuarioNo = HttpContext.Session.GetInt32("UsuarioNo");
        var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada");

        // Validar sesión activa
        if (!usuarioNo.HasValue || !sucursalNo.HasValue)
        {
          return Json(new { success = false, redirect = Url.Action("LoginBasic", "Auth") });
        }

        // Asignar datos al modelo
        model.centroControl.UsuarioCreacion = correoUsuario;
        model.centroControl.SucursalNo = sucursalNo.Value;
        model.centroControl.UsuarioNo = usuarioNo.Value;

        // Registrar almacén
        var result = await _almacenesService.RegisterAsync(model.centroControl);
        if (!result.Success)
          return Json(new { success = false, error = result.ErrorMessage });

        int almacenNo = result.Data;

        // Guardar imágenes si se cargaron
        bool exitoImagenes = true;
        if (model.fileInput != null && model.fileInput.Any())
        {
          exitoImagenes = await GuardarImagenesUsuarioAsync(
              almacenNo,
              model.fileInput,
              model.centroControl.UsuarioCreacion
          );
        }

        // Validar si ocurrió error con imágenes
        if (!exitoImagenes)
        {
          return Json(new { success = false, error = "El almacén fue creado, pero ocurrió un error al guardar las imágenes." });
        }

        // Todo OK
        return Json(new { success = true });
      }
      catch (Exception ex)
      {
        return Json(new
        {
          success = false,
          error = "Error inesperado al registrar el almacén. Detalle técnico: " + ex.Message
        });
      }
    }




    private async Task<bool> GuardarImagenesUsuarioAsync(int AlmacenNo, IFormFile[] archivos, string usuarioCreacion)
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
            
            var modelFile = new AlmacenesFileCreacionDto
            {
              AlmacenNo = AlmacenNo,
              NombreDocumento = "FOTOS",
              FlagTipoFoto = "EVIDENCIA",
              NombreArchivo = file.FileName,
              ContentType = file.ContentType,
              Data = imagenComprimida,
              UsuarioCreacion = usuarioCreacion
            };

            var result = await _almacenesFileService.RegisterAsync(modelFile);
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






    public async Task<ActionResult> ListadoAlmacenes()
    {

      //var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada");
      var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada") ?? 0;


      var model = new AlmacenesDto();

      // Obtener la fecha actual
      DateTime fechaActual = DateTime.Now;
      DateTime fechaDesde = fechaActual.AddMonths(-1);
      string fechaDesdeString = fechaDesde.ToString("yyyy-MM-dd");
      string fechaHastaString = fechaActual.ToString("yyyy-MM-dd");

      var data = await _almacenesService.ListadoAlmacenes(fechaDesdeString, fechaHastaString, sucursalNo);
      //var data = await _usuariosService.ListadoUsuariosConSucursale(fechaDesdeString, fechaHastaString);


      if (data.Data == null)
      {
        data.Data = new List<AlmacenesColeccionDto>();
      }
      var datos = data.Data.ToList();

      //for (int i = 0; i < datos.Count; i++)
      //{
      //    datos[i].Numero = i + 1;
      //}

      model = new AlmacenesDto
      {
        lstCentroControl = datos,
        FechaDesde = fechaDesdeString,
        FechaHasta = fechaHastaString,

      };

      return View(model);
    }



    [HttpPost]
    public async Task<ActionResult> ListadoAlmacenes(AlmacenesDto model)
    {
      //var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada");
      var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada") ?? 0;


      var fechaDesde = (string.IsNullOrEmpty(model.FechaDesde)) ? null : Convert.ToDateTime(model.FechaDesde).ToString("yyyy-MM-dd");
      var fechaHasta = (string.IsNullOrEmpty(model.FechaHasta)) ? null : Convert.ToDateTime(model.FechaHasta).ToString("yyyy-MM-dd");

      var data = await _almacenesService.ListadoAlmacenes(fechaDesde, fechaHasta, sucursalNo);

      if (data.Data == null)
      {
        data.Data = new List<AlmacenesColeccionDto>();
      }
      var datos = data.Data.ToList();


      var model2 = new AlmacenesDto
      {
        //lstCentroControl = data.Data.ToList(),
        lstCentroControl = datos,
        FechaDesde = fechaDesde,
        FechaHasta = fechaHasta
      };
      return View(model2);
    }







    public IActionResult Index()
    {
      return View();
    }
  }
}
