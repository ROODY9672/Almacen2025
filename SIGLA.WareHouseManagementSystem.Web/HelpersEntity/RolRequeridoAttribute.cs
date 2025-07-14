using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace SIGLA.WareHouseManagementSystem.Web.HelpersEntity
{
  public class RolRequeridoAttribute : Attribute, IActionFilter
  {
    private readonly string[] _rolesPermitidos;

    public RolRequeridoAttribute(params string[] rolesPermitidos)
    {
      _rolesPermitidos = rolesPermitidos;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
      var session = context.HttpContext.Session;

      var rol = session.GetString("Rol");
      var usuarioNo = session.GetString("UsuarioNo");

      if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(usuarioNo))
      {
        context.Result = new RedirectToActionResult("IniciarSesion", "Login", null);
        return;
      }

      // Validamos si el rol del usuario está dentro de los permitidos
      bool accesoPermitido = _rolesPermitidos.Any(r =>
          string.Equals(r.Trim(), rol, StringComparison.OrdinalIgnoreCase)
      );

      if (!accesoPermitido)
      {
        context.Result = new RedirectToActionResult("AccesoDenegado", "Home", null);
      }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      // No implementado
    }
  }
}
