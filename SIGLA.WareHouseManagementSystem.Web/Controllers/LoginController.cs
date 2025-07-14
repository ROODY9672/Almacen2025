using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Business.Services.Wrapper.IService;
using System;
using System.Threading.Tasks;

namespace SIGLA.WareHouseManagementSystem.Web.Controllers
{
  public class LoginController : Controller
  {
    private readonly IUsuariosService _usuariosService;

    public LoginController(IUsuariosService usuariosService)
    {
      _usuariosService = usuariosService;
    }

    [HttpGet]
    public IActionResult IniciarSesion()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> IniciarSesion(UsuarioLoginDto dto)
    {
      if (!ModelState.IsValid)
      {
        return View(dto);
      }

      dto.Clave = HashHelper.ToSHA256(dto.Clave);

      var usuario = await _usuariosService.ValidarLogin(dto);

      if (usuario != null)
      {
        // 🔐 Guardamos variables en sesión
        HttpContext.Session.SetString("UsuarioNo", usuario.UsuarioNo.ToString());
        HttpContext.Session.SetString("SucursalNo", usuario.SucursalNo.ToString());
        HttpContext.Session.SetString("Rol", usuario.Rol);
        HttpContext.Session.SetString("NombreUsuario", usuario.NombreUsuario);

        // Si quieres usar autenticación basada en cookie, aquí podrías usar Identity o Claims (si lo implementas)
        //return RedirectToAction("Index", "Home");
        return RedirectToAction("UsuarioSucursalAsignado", "Usuarios");
      }

      ViewBag.Error = "Credenciales incorrectas.";
      return View(dto);
    }

    [HttpGet]
    public IActionResult CerrarSesion()
    {
      // Limpia variables de sesión
      HttpContext.Session.Clear();

      // Si manejas cookies personalizadas, puedes eliminarlas así:
      if (Request.Cookies.ContainsKey("CookieInicioSesion"))
      {
        Response.Cookies.Delete("CookieInicioSesion");
      }

      return RedirectToAction("IniciarSesion", "Login");
    }









  }
}
