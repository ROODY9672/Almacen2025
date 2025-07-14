using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;

namespace SIGLA.WareHouseManagementSystem.Web.HelpersEntity
{
  public class LoginRequiredAttribute : Attribute, IActionFilter
  {
    //public void OnActionExecuting(ActionExecutingContext context)
    //{
    //  var session = context.HttpContext.Session;

    //  // Verifica si hay sesión activa
    //  if (string.IsNullOrEmpty(session.GetString("UsuarioNo")))
    //  {
    //    context.Result = new RedirectToActionResult("IniciarSesion", "Login", null);
    //    return;
    //  }

    //  // Bloqueo de caché para evitar volver con el botón "atrás"
    //  var response = context.HttpContext.Response;
    //  response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
    //  response.Headers["Pragma"] = "no-cache";
    //  response.Headers["Expires"] = "-1";
    //}

    //public void OnActionExecuted(ActionExecutedContext context)
    //{
    //  // No es necesario implementar esto si no lo usas
    //}





    public void OnActionExecuting(ActionExecutingContext context)
    {
      var user = context.HttpContext.User;

      // 🔐 Si no está autenticado, redirige a login
      if (!user.Identity.IsAuthenticated)
      {
        context.Result = new RedirectToActionResult("LoginBasic", "Auth", null);
        return;
      }



      // 🔒 Bloqueo de caché para que no se vea el contenido anterior
      var response = context.HttpContext.Response;
      response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, max-age=0";
      response.Headers["Pragma"] = "no-cache";
      response.Headers["Expires"] = "-1";
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      // No es necesario implementar esto por ahora
    }













  }
}
