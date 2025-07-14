using Microsoft.AspNetCore.Mvc;
using SIGLA.Business.Services.Wrapper.IService;

namespace SIGLA.WareHouseManagementSystem.Web.Controllers
{
  public class ProductoUnidadMedidaController : Controller
  {
    private readonly IProductoUnidadMedidaService _productoUnidadMedidaService;

    public ProductoUnidadMedidaController(IProductoUnidadMedidaService productoUnidadMedidaService)
    {
      this._productoUnidadMedidaService = productoUnidadMedidaService;
    }





    public IActionResult Index()
    {
      return View();
    }
  }
}
