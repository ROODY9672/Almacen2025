using Microsoft.Extensions.DependencyInjection;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Business.Services.Wrapper.Service;
using SIGLA.Interface.Repository;
using SIGLA.DataAccess.Repository;

namespace SIGLA.WareHouseManagementSystem.Web.Configuration
{
  public static class DependencyInjectionConfig
  {
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
      // Mappers
      services.AddScoped<IMappingGeneric, MappingGeneric>();

      // Servicios
      services.AddScoped<IAtencionProveedorService, AtencionProveedorService>();
      services.AddScoped<IAlmacenesService, AlmacenesService>();
      services.AddScoped<IClientesService, ClientesService>();
      services.AddScoped<IComprasService, ComprasService>();
      services.AddScoped<ICompraDetalleService, CompraDetalleService>();
      services.AddScoped<IProductoStockService, ProductoStockService>();
      services.AddScoped<IProductoService, ProductoService>();
      services.AddScoped<IProveedoresService, ProveedoresService>();
      services.AddScoped<IVentasService, VentasService>();
      services.AddScoped<IVentasDetalleService, VentasDetalleService>();
      services.AddScoped<ISucursalesService, SucursalesService>();
      services.AddScoped<IUsuariosService, UsuariosService>();
      services.AddScoped<IUsuarioSucursalService, UsuarioSucursalService>();
      services.AddScoped<IUsuariosFileService,  UsuariosFileService>();
      services.AddScoped<ISucursalesFileService,  SucursalesFileService>();
      services.AddScoped<IEmpresaService,  EmpresaService>();
      services.AddScoped<IAlmacenesFileService,  AlmacenesFileService>();
      services.AddScoped<IProductoCategoriaService,  ProductoCategoriaService>();
      services.AddScoped<IProductoMarcaService,  ProductoMarcaService>();
      services.AddScoped<IProductoUnidadMedidaService,  ProductoUnidadMedidaService>();
      services.AddScoped<IProductoFileService,  ProductoFileService>();

      services.AddScoped<IMarcaSucursalService,  MarcaSucursalService>();
    



      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


      // UnitOfWork con conexión desde appsettings.json
      var connectionString = configuration.GetConnectionString("WarehouseManagement");
      services.AddScoped<IUnitOfWork>(provider => new UnitOfWork(connectionString));
    }
  }
}
