using Microsoft.AspNetCore.Mvc;
using SIGLA.Business.Services.Wrapper.IService;

namespace SIGLA.WareHouseManagementSystem.Web.Controllers
{
  public class ProductoController : Controller
  {

    private readonly IProductoStockService _productoStockService;
    private readonly IProductoService _productoService;
    private readonly IProductoCategoriaService _productoCategoriaService;
    private readonly IProductoMarcaService _productoMarcaService;
    private readonly IProductoUnidadMedidaService _productoUnidadMedidaService;
    private readonly IProductoFileService _productoFileService;

    public ProductoController(
        IProductoStockService productoStockService,
        IProductoService productoService,
        IProductoCategoriaService productoCategoriaService,
        IProductoMarcaService productoMarcaService,
        IProductoUnidadMedidaService productoUnidadMedidaService,
        IProductoFileService productoFileService)
    {
      _productoStockService = productoStockService;
      _productoService = productoService;
      _productoCategoriaService = productoCategoriaService;
      _productoMarcaService = productoMarcaService;
      _productoUnidadMedidaService = productoUnidadMedidaService;
      _productoFileService = productoFileService;
    }










    public IActionResult Index()
    {
      return View();
    }
  }
}
