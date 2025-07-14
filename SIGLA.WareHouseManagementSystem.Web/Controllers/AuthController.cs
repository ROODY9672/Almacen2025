using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.UsuarioSucursalsss;
using SIGLA.Business.Services.Wrapper.Service;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace AspnetCoreMvcFull.Controllers;

public class AuthController : Controller
{

  private readonly IUsuariosService _usuariosService;

  public AuthController(

    IUsuariosService usuariosService)
  {
    _usuariosService = usuariosService;
  }




  public IActionResult ForgotPasswordBasic() => View();
  public IActionResult ForgotPasswordCover() => View();
  //public IActionResult LoginBasic() => View();
  public IActionResult LoginCover() => View();
  public IActionResult RegisterBasic() => View();
  public IActionResult RegisterCover() => View();
  public IActionResult RegisterMultiSteps() => View();
  public IActionResult ResetPasswordBasic() => View();
  public IActionResult ResetPasswordCover() => View();
  public IActionResult TwoStepsBasic() => View();
  public IActionResult TwoStepsCover() => View();
  public IActionResult VerifyEmailBasic() => View();
  public IActionResult VerifyEmailCover() => View();







  //[HttpGet]
  //public IActionResult LoginBasic()
  //{
  //  TempData["appName"] = "MI PRESU";

  //  var dto = new UsuarioLoginDto();

  //  // ✅ Leer cookie si existe
  //  if (Request.Cookies.TryGetValue("CorreoRecordado", out var correoRecordado))
  //  {
  //    dto.Correo = correoRecordado;
  //  }

  //  return View(dto);
  //}



  //[HttpPost]
  //public async Task<IActionResult> LoginBasic(UsuarioLoginDto dto, bool Recordarme = false)
  //{
  //  if (!ModelState.IsValid)
  //  {
  //    return View(dto);
  //  }



  //  dto.Clave = HashHelper.ToSHA256(dto.Clave);
  //  var usuario = await _usuariosService.ValidarLogin(dto);

  //  if (usuario != null)
  //  {
  //    HttpContext.Session.SetString("UsuarioNo", usuario.UsuarioNo.ToString());
  //    HttpContext.Session.SetString("SucursalNo", usuario.SucursalNo.ToString());
  //    HttpContext.Session.SetString("NombreUsuario", usuario.NombreUsuario);

  //    // ✅ Guardar cookie si el usuario marcó "Recordarme"
  //    if (Recordarme)
  //    {
  //      CookieOptions opciones = new CookieOptions
  //      {
  //        Expires = DateTime.Now.AddDays(7),
  //        IsEssential = true,
  //        HttpOnly = true,
  //      };

  //      Response.Cookies.Append("CorreoRecordado", dto.Correo, opciones);
  //    }
  //    else
  //    {
  //      Response.Cookies.Delete("CorreoRecordado");
  //    }

  //    return RedirectToAction("Index", "Home");
  //  }

  //  ViewBag.Error = "Correo invalido o contraseña incorrectas.";
  //  return View(dto);
  //}





  [HttpGet]
  public IActionResult LoginBasic()
  {
    TempData["appName"] = "MI PRESU";

    var model = new UsuarioLoginDto();

    if (Request.Cookies.TryGetValue("CorreoRecordado", out var correoGuardado))
    {
      model.Correo = correoGuardado;
      model.Recordarme = true;
    }

    return View(model);
  }


  [HttpPost]
  public async Task<IActionResult> LoginBasic(UsuarioLoginDto dto)
  {
    if (!ModelState.IsValid)
      return View(dto);

    dto.Clave = HashHelper.ToSHA256(dto.Clave);
    var usuario = await _usuariosService.ValidarLogin(dto);

    if (usuario != null)
    {
      var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioNo.ToString()),
            new Claim(ClaimTypes.Name, usuario.NombreUsuario),
            new Claim(ClaimTypes.Email, usuario.Correo), 
            new Claim("SucursalNo", usuario.SucursalNo.ToString())
        };

      var identity = new ClaimsIdentity(claims, "MyCookieAuth");
      var principal = new ClaimsPrincipal(identity);

      var authProperties = new AuthenticationProperties
      {
        IsPersistent = true,
        //ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7) ahora esta en calse Program.cs
      };

      await HttpContext.SignInAsync("MyCookieAuth", principal, authProperties);

      // ✅ Aquí sí usamos dto.Recordarme
      if (dto.Recordarme)
      {
        Response.Cookies.Append("CorreoRecordado", dto.Correo, new CookieOptions
        {
          Expires = DateTimeOffset.UtcNow.AddDays(7),
          IsEssential = true,
          HttpOnly = false
        });
      }
      else
      {
        Response.Cookies.Delete("CorreoRecordado");
      }

      //return RedirectToAction("Index", "Home");
      return RedirectToAction("UsuarioSucursalAsignado", "Usuarios");

    }

    ViewBag.Error = "Correo o contraseña incorrectos.";
    return View(dto); // <-- aseguramos que dto.Recordarme vuelva a la vista
  }



   


  [HttpPost]
  public async Task<IActionResult> RegisterCover(UsuariosCreacionDto dto )
  {
    if (!ModelState.IsValid)
    {
      // Variable para almacenar todos los errores detallados
      var erroresDetallados = new StringBuilder();

      foreach (var modelState in ModelState)
      {
        var campo = modelState.Key;
        var errores = modelState.Value.Errors;

        foreach (var error in errores)
        {
          erroresDetallados.AppendLine($"Campo: {campo} - Error: {error.ErrorMessage}");
        }
      }

      // Aquí puedes imprimirlo en consola o loguearlo
      string erroresComoTexto = erroresDetallados.ToString();
      Console.WriteLine("ERRORES DE VALIDACIÓN:");
      Console.WriteLine(erroresComoTexto);

      // También puedes pasarlo a ViewBag si deseas mostrarlo en la vista:
      // ViewBag.Errores = erroresComoTexto;

      return View(dto);
    }


    if (dto.Clave != dto.ConfirmarClave)
    {
      ModelState.AddModelError("ConfirmarClave", "Las contraseñas no coinciden");
      return View(dto);
    }



    dto.UsuarioCreacion = "SYSADMIN";
    dto.ClaveHash = HashHelper.ToSHA256(dto.Clave);

    var result = await _usuariosService.RegisterAsync(dto);

    if (result.Success)
    {
      // lógica opcional de sucursales
      //return RedirectToAction("Login", "Auth"); // o cualquier otra acción
      return RedirectToAction("Index", "Home");

    }

    ModelState.AddModelError(string.Empty, result.ErrorMessage);
    return View(dto);
  }




  public async Task<IActionResult> CerrarSesion()
  {
    // 🔐 Cierra la sesión del usuario (borra la cookie de autenticación)
    await HttpContext.SignOutAsync("MyCookieAuth");

    // 🧹 Limpia también la sesión (opcional si aún usas Session para otras cosas)
    HttpContext.Session.Clear();

    // Redirige al login
    return RedirectToAction("LoginBasic", "Auth");
  }



 





}
