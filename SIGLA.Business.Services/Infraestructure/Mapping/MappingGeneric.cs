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
    public class MappingGeneric : IMappingGeneric
    {
        public MappingGeneric()
        {
            this.AtencionProveedorMapping = new AtencionProveedorMapping();
            this.AlmacenesMapping = new AlmacenesMapping(); 
            this.ComprasMapping = new ComprasMapping(); 
            this.CompraDetalleMapping = new CompraDetalleMapping(); 
            this.ProductoStockMapping = new ProductoStockMapping();


            this.ProductoMapping = new ProductoMapping();
            this.ProveedoresMapping = new ProveedoresMapping();
            this.VentasMapping = new VentasMapping();
            this.VentasDetalleMapping = new VentasDetalleMapping();
            this.SucursalesMapping = new SucursalesMapping();
            this.UsuariosMapping = new UsuariosMapping();
            this.UsuarioSucursalMapping = new UsuarioSucursalMapping();
            this.UsuariosFileMapping = new UsuariosFileMapping();
            this.ClientesMapping = new ClientesMapping();
            this.SucursalesFileMapping = new SucursalesFileMapping();
            this.EmpresaMapping = new EmpresaMapping();
            this.AlmacenesFileMapping = new AlmacenesFileMapping();


            this.ProductoCategoriaMapping = new ProductoCategoriaMapping();
            this.ProductoMarcaMapping = new ProductoMarcaMapping();
            this.ProductoUnidadMedidaMapping = new ProductoUnidadMedidaMapping();
            this.ProductoFileMapping = new ProductoFileMapping();

            this.MarcaSucursalMapping = new MarcaSucursalMapping();

            
        }

        public IAtencionProveedorMapping  AtencionProveedorMapping { get; private set; }

        public IAlmacenesMapping AlmacenesMapping { get; private set; }

        public IClientesMapping ClientesMapping { get; private set; }

        public IComprasMapping ComprasMapping { get; private set; }

        public ICompraDetalleMapping CompraDetalleMapping { get; private set; }

        public IProductoStockMapping ProductoStockMapping { get; private set; }

        public IProductoMapping ProductoMapping { get; private set; }

        public IProveedoresMapping ProveedoresMapping { get; private set; }

        public IVentasMapping VentasMapping { get; private set; }

        public IVentasDetalleMapping VentasDetalleMapping { get; private set; }

        public ISucursalesMapping SucursalesMapping { get; private set; }

        public IUsuariosMapping UsuariosMapping { get; private set; }

        public IUsuarioSucursalMapping UsuarioSucursalMapping { get; private set; }

        public IUsuariosFileMapping UsuariosFileMapping { get; private set; }

        public ISucursalesFileMapping SucursalesFileMapping { get; private set; }

        public IEmpresaMapping EmpresaMapping { get; private set; }

        public IAlmacenesFileMapping AlmacenesFileMapping { get; private set; }

        public IProductoCategoriaMapping ProductoCategoriaMapping { get; private set; }

        public IProductoMarcaMapping ProductoMarcaMapping { get; private set; }

        public IProductoUnidadMedidaMapping ProductoUnidadMedidaMapping { get; private set; }

        public IProductoFileMapping ProductoFileMapping { get; private set; }

        public IMarcaSucursalMapping MarcaSucursalMapping { get; private set; }
    }
}
