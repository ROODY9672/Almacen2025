using Microsoft.AspNetCore.Mvc;
using SIGLA.Business.Dto.Almacenessss;
using SIGLA.Business.Dto.MarcaSucursalsss;
using SIGLA.Business.Dto.ProductoMarcasss;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Business.Services.Wrapper.Service;
using System.Security.Claims;

namespace SIGLA.WareHouseManagementSystem.Web.Controllers
{
  public class ProductoMarcaController : Controller
  {
    private readonly IProductoMarcaService _productoMarcaService;
    private readonly IMarcaSucursalService _marcaSucursalService;

    public ProductoMarcaController(IProductoMarcaService productoMarcaService,
      IMarcaSucursalService marcaSucursalService)
    {
      this._productoMarcaService = productoMarcaService;
      this._marcaSucursalService = marcaSucursalService;
    }


    [HttpGet]
    public async Task<ActionResult> RegistrarMarca()
    {

      var model = new ProductoMarcaYImageViewModel
      {
        centroControl = new ProductoMarcaCreacionDto(),


      };

      return View(model);
    }









    //[HttpPost]
    //public async Task<JsonResult> RegistrarMarca(ProductoMarcaYImageViewModel model)
    //{
    //  try
    //  {
    //    string correoUsuario = User.FindFirstValue(ClaimTypes.Email) ?? "NO_CORREO";
    //    var usuarioNo = HttpContext.Session.GetInt32("UsuarioNo");
    //    var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada");

    //    if (!usuarioNo.HasValue || !sucursalNo.HasValue)
    //    {
    //      return Json(new { success = false, redirect = Url.Action("LoginBasic", "Auth") });
    //    }

    //    // Limpiar espacios al inicio y final antes de buscar y guardar
    //    model.centroControl.Descripcion = model.centroControl.Descripcion?.Trim();

    //    // Validar si ya existe la marca (buscando por descripción limpia)
    //    var marcaExistente = await _productoMarcaService.BuscarPorNombreAsync(model.centroControl.Descripcion);

    //    int marcaId;
    //    bool esNuevo = false;

    //    if (marcaExistente.Data != null)
    //    {
    //      marcaId = marcaExistente.Data.ProductoMarcaNo;
    //    }
    //    else
    //    {
    //      // Registrar la nueva marca con descripción limpia
    //      model.centroControl.UsuarioCreacion = correoUsuario;

    //      var result = await _productoMarcaService.RegisterAsync(model.centroControl);
    //      if (!result.Success)
    //        return Json(new { success = false, error = result.ErrorMessage });

    //      marcaId = result.Data;
    //      esNuevo = true; // Se insertó una marca nueva
    //    }

    //    // Verificar si ya existe relación Marca-Sucursal
    //    var yaExisteRelacion = await _marcaSucursalService.ExisteRelacionAsync(marcaId, sucursalNo.Value);
    //    if (!yaExisteRelacion)
    //    {
    //      var relacionDto = new MarcaSucursalCreacionDto
    //      {
    //        ProductoMarcaNo = marcaId,
    //        SucursalNo = sucursalNo.Value
    //      };

    //      var relacionInsertada = await _marcaSucursalService.RegisterAsync(relacionDto);

    //      if (relacionInsertada.Success)
         
    //      esNuevo = true; // Se insertó una marca nueva
    //        return Json(new { success = true, error = 'Se inserto marca en Sucursal' , });

    //      if (!relacionInsertada.Success)
    //        return Json(new { success = false, error = relacionInsertada.ErrorMessage });
    //    }

    //    return Json(new { success = true, esNuevo = esNuevo });
    //  }
    //  catch (Exception ex)
    //  {
    //    return Json(new
    //    {
    //      success = false,
    //      error = "Error inesperado al registrar la marca. Detalle técnico: " + ex.Message
    //    });
    //  }
    //}

    [HttpPost]
    public async Task<JsonResult> RegistrarMarca(ProductoMarcaYImageViewModel model)
    {
      try
      {
        string correoUsuario = User.FindFirstValue(ClaimTypes.Email) ?? "NO_CORREO";
        var usuarioNo = HttpContext.Session.GetInt32("UsuarioNo");
        var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada");

        if (!usuarioNo.HasValue || !sucursalNo.HasValue)
        {
          return Json(new { success = false, redirect = Url.Action("LoginBasic", "Auth") });
        }

        // Limpiar espacios en la descripción
        model.centroControl.Descripcion = model.centroControl.Descripcion?.Trim();

        // Buscar si la marca ya existe
        var marcaExistente = await _productoMarcaService.BuscarPorNombreAsync(model.centroControl.Descripcion);

        int marcaId;
        bool esNuevo = false;

        if (marcaExistente.Data != null)
        {
          marcaId = marcaExistente.Data.ProductoMarcaNo;
        }
        else
        {
          model.centroControl.UsuarioCreacion = correoUsuario;
          var result = await _productoMarcaService.RegisterAsync(model.centroControl);

          if (!result.Success)
            return Json(new { success = false, error = result.ErrorMessage });

          marcaId = result.Data;
          esNuevo = true; // Marca nueva registrada
        }

        // Verificar si existe relación Marca-Sucursal
        var yaExisteRelacion = await _marcaSucursalService.ExisteRelacionAsync(marcaId, sucursalNo.Value);

        if (!yaExisteRelacion)
        {
          var relacionDto = new MarcaSucursalCreacionDto
          {
            ProductoMarcaNo = marcaId,
            SucursalNo = sucursalNo.Value
          };

          var relacionInsertada = await _marcaSucursalService.RegisterAsync(relacionDto);

          if (!relacionInsertada.Success)
            return Json(new { success = false, error = relacionInsertada.ErrorMessage });

          return Json(new { success = true, mensaje = "Se insertó la marca en la sucursal correctamente", esNuevo = true });
        }

        // Si ya existe la relación o solo se registró la marca
        return Json(new { success = true, mensaje = esNuevo ? "Se registró nueva marca" : "La marca ya existe", esNuevo });
      }
      catch (Exception ex)
      {
        return Json(new
        {
          success = false,
          error = "Error inesperado al registrar la marca. Detalle técnico: " + ex.Message
        });
      }
    }


    //public async Task<ActionResult> ListadoAlmacenes()
    //{

    //  //var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada");
    //  var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada") ?? 0;


    //  var model = new AlmacenesDto();

    //  // Obtener la fecha actual
    //  DateTime fechaActual = DateTime.Now;
    //  DateTime fechaDesde = fechaActual.AddMonths(-1);
    //  string fechaDesdeString = fechaDesde.ToString("yyyy-MM-dd");
    //  string fechaHastaString = fechaActual.ToString("yyyy-MM-dd");

    //  var data = await _almacenesService.ListadoAlmacenes(fechaDesdeString, fechaHastaString, sucursalNo);
    //  //var data = await _usuariosService.ListadoUsuariosConSucursale(fechaDesdeString, fechaHastaString);


    //  if (data.Data == null)
    //  {
    //    data.Data = new List<AlmacenesColeccionDto>();
    //  }
    //  var datos = data.Data.ToList();

    //  //for (int i = 0; i < datos.Count; i++)
    //  //{
    //  //    datos[i].Numero = i + 1;
    //  //}

    //  model = new AlmacenesDto
    //  {
    //    lstCentroControl = datos,
    //    FechaDesde = fechaDesdeString,
    //    FechaHasta = fechaHastaString,

    //  };

    //  return View(model);
    //}



    //[HttpPost]
    //public async Task<ActionResult> ListadoAlmacenes(AlmacenesDto model)
    //{
    //  //var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada");
    //  var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada") ?? 0;


    //  var fechaDesde = (string.IsNullOrEmpty(model.FechaDesde)) ? null : Convert.ToDateTime(model.FechaDesde).ToString("yyyy-MM-dd");
    //  var fechaHasta = (string.IsNullOrEmpty(model.FechaHasta)) ? null : Convert.ToDateTime(model.FechaHasta).ToString("yyyy-MM-dd");

    //  var data = await _almacenesService.ListadoAlmacenes(fechaDesde, fechaHasta, sucursalNo);

    //  if (data.Data == null)
    //  {
    //    data.Data = new List<AlmacenesColeccionDto>();
    //  }
    //  var datos = data.Data.ToList();


    //  var model2 = new AlmacenesDto
    //  {
    //    //lstCentroControl = data.Data.ToList(),
    //    lstCentroControl = datos,
    //    FechaDesde = fechaDesde,
    //    FechaHasta = fechaHasta
    //  };
    //  return View(model2);
    //}







    public async Task<ActionResult> ListadoProductoMarca()
    {

      //var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada");
      var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada") ?? 0;


      var model = new ProductoMarcaDto();

      // Obtener la fecha actual
      DateTime fechaActual = DateTime.Now;
      DateTime fechaDesde = fechaActual.AddMonths(-1);
      string fechaDesdeString = fechaDesde.ToString("yyyy-MM-dd");
      string fechaHastaString = fechaActual.ToString("yyyy-MM-dd");

      var data = await _productoMarcaService.ListadoProductoMarca(fechaDesdeString, fechaHastaString, sucursalNo);
      //var data = await _usuariosService.ListadoUsuariosConSucursale(fechaDesdeString, fechaHastaString);


      if (data.Data == null)
      {
        data.Data = new List<ProductoMarcaColeccionDto>();
      }
      var datos = data.Data.ToList();

      //for (int i = 0; i < datos.Count; i++)
      //{
      //    datos[i].Numero = i + 1;
      //}

      model = new ProductoMarcaDto
      {
        lstCentroControl = datos,
        FechaDesde = fechaDesdeString,
        FechaHasta = fechaHastaString,

      };

      return View(model);
    }



    [HttpPost]
    public async Task<ActionResult> ListadoProductoMarca(ProductoMarcaDto model)
    {
      //var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada");
      var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada") ?? 0;


      var fechaDesde = (string.IsNullOrEmpty(model.FechaDesde)) ? null : Convert.ToDateTime(model.FechaDesde).ToString("yyyy-MM-dd");
      var fechaHasta = (string.IsNullOrEmpty(model.FechaHasta)) ? null : Convert.ToDateTime(model.FechaHasta).ToString("yyyy-MM-dd");

      var data = await _productoMarcaService.ListadoProductoMarca(fechaDesde, fechaHasta, sucursalNo);

      if (data.Data == null)
      {
        data.Data = new List<ProductoMarcaColeccionDto>();
      }
      var datos = data.Data.ToList();


      var model2 = new ProductoMarcaDto
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
