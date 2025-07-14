using SIGLA.Business.Services.Infraestructure.Mapping.AlmacenesFiless;
using SIGLA.Business.Services.Infraestructure.Mapping.Almacenesss;
using SIGLA.Business.Services.Infraestructure.Mapping.AtencionProveedorss;
using SIGLA.Business.Services.Infraestructure.Mapping.Clientessss;
using SIGLA.Business.Services.Infraestructure.Mapping.CompraDetalless;
using SIGLA.Business.Services.Infraestructure.Mapping.Comprasss;
using SIGLA.Business.Services.Infraestructure.Mapping.Empresass;
using SIGLA.Business.Services.Infraestructure.Mapping.MarcaSucursalss;
using SIGLA.Business.Services.Infraestructure.Mapping.ProductoCategoriass;
using SIGLA.Business.Services.Infraestructure.Mapping.ProductoFiless;
using SIGLA.Business.Services.Infraestructure.Mapping.ProductoMarcass;
using SIGLA.Business.Services.Infraestructure.Mapping.Productoss;
using SIGLA.Business.Services.Infraestructure.Mapping.ProductoStockss;
using SIGLA.Business.Services.Infraestructure.Mapping.ProductoUnidadMedidass;
using SIGLA.Business.Services.Infraestructure.Mapping.Proveedoresss;
using SIGLA.Business.Services.Infraestructure.Mapping.SucursalesFilesss;
using SIGLA.Business.Services.Infraestructure.Mapping.Sucursalesss;
using SIGLA.Business.Services.Infraestructure.Mapping.UsuariosFiless;
using SIGLA.Business.Services.Infraestructure.Mapping.Usuariosss;
using SIGLA.Business.Services.Infraestructure.Mapping.UsuarioSucursalss;
using SIGLA.Business.Services.Infraestructure.Mapping.VentasDetalless;
using SIGLA.Business.Services.Infraestructure.Mapping.Ventasss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure
{
    public interface IMappingGeneric
    {
        IAtencionProveedorMapping  AtencionProveedorMapping { get; }
        IAlmacenesMapping  AlmacenesMapping { get; }
        IClientesMapping  ClientesMapping { get; }
        IComprasMapping  ComprasMapping { get; }
        ICompraDetalleMapping  CompraDetalleMapping { get; }
        IProductoStockMapping  ProductoStockMapping { get; }
        IProductoMapping  ProductoMapping { get; }
        IProveedoresMapping  ProveedoresMapping { get; }
        IVentasMapping  VentasMapping { get; }
        IVentasDetalleMapping  VentasDetalleMapping { get; }
        ISucursalesMapping  SucursalesMapping { get; }
        IUsuariosMapping  UsuariosMapping { get; }
        IUsuarioSucursalMapping  UsuarioSucursalMapping { get; }
        IUsuariosFileMapping  UsuariosFileMapping { get; }
        ISucursalesFileMapping  SucursalesFileMapping { get; }
        IEmpresaMapping EmpresaMapping { get; }
        IAlmacenesFileMapping  AlmacenesFileMapping { get; }
        IProductoCategoriaMapping  ProductoCategoriaMapping { get; }
        IProductoMarcaMapping  ProductoMarcaMapping { get; }
        IProductoUnidadMedidaMapping  ProductoUnidadMedidaMapping { get; }


        IProductoFileMapping  ProductoFileMapping { get; }

        IMarcaSucursalMapping  MarcaSucursalMapping { get; }


        


    }
}
