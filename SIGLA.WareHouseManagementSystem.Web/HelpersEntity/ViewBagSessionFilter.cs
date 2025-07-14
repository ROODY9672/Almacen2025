using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SIGLA.Entity.DataBase.Empresa;
using SIGLA.Entity.DataBase.Usuarios;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace SIGLA.WareHouseManagementSystem.Web.HelpersEntity
{
  public class ViewBagSessionFilter : IActionFilter
  {


    public void OnActionExecuting(ActionExecutingContext context)
    {
      var controller = context.Controller as Controller;
      var httpContext = context.HttpContext;

      var routeData = context.RouteData;
      var currentController = routeData.Values["controller"]?.ToString();
      var currentAction = routeData.Values["action"]?.ToString();

      // ⚠️ Excepciones: ignora ciertas vistas donde no debe forzar sesión
      var controladoresIgnorados = new[] { "Auth", "Usuarios" }; // Login y selección de sucursal
      var accionesIgnoradas = new[] { "LoginBasic", "UsuarioSucursalAsignado" };

      if (controladoresIgnorados.Contains(currentController) || accionesIgnoradas.Contains(currentAction))
      {
        return; // no aplica filtro en estas acciones
      }
      //      string claveActual = $"{currentController}:{currentAction}";

      //      var excepciones = new[]
      //      {
      //    "Auth:LoginBasic",
      //    "Usuarios:UsuarioSucursalAsignado",
      //    "Usuarios:SeleccionarSucursal"
      //};

      //      if (excepciones.Contains(claveActual))
      //      {
      //        return; // No aplicar el filtro si está en la lista de excepciones
      //      }


  



      if (controller != null)
      {
        if (httpContext.Session.GetInt32("SucursalSeleccionada") == null)
        {
          controller.TempData["SesionExpirada"] = "Tu sesión expiró, por favor selecciona una sucursal nuevamente.";

          context.Result = new RedirectToRouteResult(
              new RouteValueDictionary(new
              {
                controller = "Usuarios",
                action = "UsuarioSucursalAsignado"
              })
          );
          return;
        }

        controller.ViewBag.UsuarioNo = httpContext.Session.GetInt32("UsuarioNo");
        controller.ViewBag.NombreUsuario = httpContext.Session.GetString("NombreUsuario");
        controller.ViewBag.SucursalNo = httpContext.Session.GetInt32("SucursalSeleccionada");
        controller.ViewBag.UsuarioSucursalNo = httpContext.Session.GetInt32("UsuarioSucursalSeleccionado");
        controller.ViewBag.usuarioActual = httpContext.User.Identity?.Name ?? "SYSADMIN";

        controller.ViewBag.Sede = httpContext.Session.GetString("Sede");
        controller.ViewBag.Direccion = httpContext.Session.GetString("Direccion");
        controller.ViewBag.Sucursal = httpContext.Session.GetString("Sucursal");

        controller.ViewBag.EmpresaRazonSocial = httpContext.Session.GetString("EmpresaRazonSocial");
        controller.ViewBag.EmpresaRUC = httpContext.Session.GetString("EmpresaRUC");
        controller.ViewBag.EmpresaTelefono1 = httpContext.Session.GetString("EmpresaTelefono1");
        controller.ViewBag.EmpresaTelefono2 = httpContext.Session.GetString("EmpresaTelefono2");
        controller.ViewBag.EmpresaCorreo = httpContext.Session.GetString("EmpresaCorreo");
      }
    }





    //public void OnActionExecuting(ActionExecutingContext context)
    //{
    //  var controller = context.Controller as Controller;
    //  var httpContext = context.HttpContext;

    //  var routeData = context.RouteData;
    //  var currentController = routeData.Values["controller"]?.ToString();
    //  var currentAction = routeData.Values["action"]?.ToString();

    //  // ✅ Acciones que deben ser ignoradas completamente
    //  var excepciones = new[]
    //  {
    //    "Auth:LoginBasic",
    //    "Usuarios:UsuarioSucursalAsignado",
    //    "Usuarios:SeleccionarSucursal"
    //};
    //  var claveActual = $"{currentController}:{currentAction}";

    //  // ✅ 1. Si el usuario NO está logueado → redirigir a LoginBasic
    //  if (!httpContext.User.Identity.IsAuthenticated)
    //  {
    //    if (!excepciones.Contains(claveActual))
    //    {
    //      context.Result = new RedirectToRouteResult(
    //          new RouteValueDictionary(new
    //          {
    //            controller = "Auth",
    //            action = "LoginBasic"
    //          })
    //      );
    //    }
    //    return; // Ya lo redirigiste
    //  }

    //  // ✅ 2. Si está logueado pero acción está en excepciones → salir del filtro
    //  if (excepciones.Contains(claveActual))
    //  {
    //    return;
    //  }

    //  // ✅ 3. Si no tiene sucursal seleccionada → redirigir a selección
    //  if (httpContext.Session.GetInt32("SucursalSeleccionada") == null)
    //  {
    //    if (controller != null)
    //    {
    //      controller.TempData["SesionExpirada"] = "Tu sesión expiró, por favor selecciona una sucursal nuevamente.";
    //    }

    //    context.Result = new RedirectToRouteResult(
    //        new RouteValueDictionary(new
    //        {
    //          controller = "Usuarios",
    //          action = "UsuarioSucursalAsignado"
    //        })
    //    );
    //    return;
    //  }

    //  // ✅ 4. Si todo está bien, llenar los ViewBag
    //  if (controller != null)
    //  {
    //    controller.ViewBag.UsuarioNo = httpContext.Session.GetInt32("UsuarioNo");
    //    controller.ViewBag.NombreUsuario = httpContext.Session.GetString("NombreUsuario");
    //    controller.ViewBag.SucursalNo = httpContext.Session.GetInt32("SucursalSeleccionada");
    //    controller.ViewBag.UsuarioSucursalNo = httpContext.Session.GetInt32("UsuarioSucursalSeleccionado");
    //    controller.ViewBag.usuarioActual = httpContext.User.Identity?.Name ?? "SYSADMIN";

    //    controller.ViewBag.Sede = httpContext.Session.GetString("Sede");
    //    controller.ViewBag.Direccion = httpContext.Session.GetString("Direccion");
    //    controller.ViewBag.Sucursal = httpContext.Session.GetString("Sucursal");

    //    controller.ViewBag.EmpresaRazonSocial = httpContext.Session.GetString("EmpresaRazonSocial");
    //    controller.ViewBag.EmpresaRUC = httpContext.Session.GetString("EmpresaRUC");
    //    controller.ViewBag.EmpresaTelefono1 = httpContext.Session.GetString("EmpresaTelefono1");
    //    controller.ViewBag.EmpresaTelefono2 = httpContext.Session.GetString("EmpresaTelefono2");
    //    controller.ViewBag.EmpresaCorreo = httpContext.Session.GetString("EmpresaCorreo");
    //  }
    //}






    public void OnActionExecuted(ActionExecutedContext context) { }









  }
}
