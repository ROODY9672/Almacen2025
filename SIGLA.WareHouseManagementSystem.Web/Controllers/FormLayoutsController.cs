using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Business.Services.Wrapper.IService;

namespace AspnetCoreMvcFull.Controllers;

public class FormLayoutsController : Controller
{
  private readonly ISucursalesService _sucursalesService;

  public FormLayoutsController(ISucursalesService sucursalesService)
  {
    this._sucursalesService = sucursalesService;
  }
  public IActionResult Horizontal() => View();
public IActionResult Vertical() => View();
public IActionResult Sticky() => View();












  [HttpGet]
  public async Task<ActionResult> Registrar()
  {

    // Obtener listado de tipo de descarga ordenado
    var listadoSucursales = await _sucursalesService.ListadoSucursalesComboBox();
    var listaOrdenadaSucursales = listadoSucursales.Data.OrderBy(tp => tp.NombreSucursal).ToList();
    ViewBag.viewSucursales = new SelectList(listaOrdenadaSucursales, "SucursalNo", "NombreSucursal");


    return View(new UsuariosCreacionDto());
  }










}
