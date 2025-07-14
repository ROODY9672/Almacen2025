using Microsoft.AspNetCore.Mvc;
using SIGLA.Business.Services.Wrapper.IService;

namespace SIGLA.WareHouseManagementSystem.Web.Controllers
{
  public class ProductoCategoriaController : Controller
  {
    private readonly IProductoCategoriaService _productoCategoriaService;

    public ProductoCategoriaController(IProductoCategoriaService productoCategoriaService )
    {
      this._productoCategoriaService = productoCategoriaService;
    }











    public IActionResult Index()
    {
      return View();
    }
  }
}
