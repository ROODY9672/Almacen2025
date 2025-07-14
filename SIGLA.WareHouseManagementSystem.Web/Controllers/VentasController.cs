using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // necesario para usar HttpContext.Session
using SIGLA.WareHouseManagementSystem.Web.HelpersEntity;
using System;
using Microsoft.IdentityModel.Tokens;

namespace SIGLA.WareHouseManagementSystem.Web.Controllers
{
  //[RolRequerido("Administrador", "Supervisor")]

  [LoginRequired]

  public class VentasController : Controller
  {
    // Protegemos el acceso con sesión
    //public IActionResult Index()
    //{
    //  var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");

    //  if (string.IsNullOrEmpty(nombreUsuario))
    //  {
    //    return RedirectToAction("IniciarSesion", "Login");
    //  }

    //  ViewBag.NombreUsuario = nombreUsuario;
    //  return View();
    //}




    public IActionResult Index()
    {
      var usuarioNo = HttpContext.Session.GetInt32("UsuarioNo");
      var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");
      var sucursalNo = HttpContext.Session.GetInt32("SucursalSeleccionada");
      var usuarioSucursalNo = HttpContext.Session.GetInt32("UsuarioSucursalSeleccionado");
      string usuarioActual = User.Identity?.Name ?? "SYSADMIN";

      if (!usuarioNo.HasValue)
      {
        return RedirectToAction("IniciarSesion", "Login");
      }

      ViewBag.UsuarioNo = usuarioNo;
      ViewBag.NombreUsuario = nombreUsuario;
      ViewBag.SucursalNo = sucursalNo;
      ViewBag.UsuarioSucursalNo = usuarioSucursalNo;
      ViewBag.usuarioActual = usuarioActual;
       
      return View();
    }





  }
}
