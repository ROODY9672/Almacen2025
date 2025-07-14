using SIGLA.DataAccess.Repository.WarehouseManagement;
using SIGLA.Interface.Repository;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Object;

namespace SIGLA.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(string statement)
        {
            this.AtencionProveedorRepository = new AtencionProveedorRepository(statement);
            this.AlmacenesRepository = new AlmacenesRepository(statement);
            this.ClientesRepository = new ClientesRepository(statement);
            this.ComprasRepository = new ComprasRepository(statement);
            this.CompraDetalleRepository = new CompraDetalleRepository(statement);
            this.ProductoStockRepository = new ProductoStockRepository(statement);
            this.ProductoRepository = new ProductoRepository(statement);
            this.ProveedoresRepository = new ProveedoresRepository(statement);
            this.VentasRepository = new VentasRepository(statement);
            this.VentasDetalleRepository = new VentasDetalleRepository(statement);
            this.SucursalesRepository = new SucursalesRepository(statement);
            this.UsuariosRepository = new UsuariosRepository(statement);
            this.UsuarioSucursalRepository = new UsuarioSucursalRepository(statement);
            this.UsuariosFileRepository = new UsuariosFileRepository(statement);
            this.SucursalesFileRepository = new SucursalesFileRepository(statement);
            this.EmpresaRepository = new EmpresaRepository(statement);
            this.AlmacenesFileRepository = new AlmacenesFileRepository(statement);
            this.ProductoCategoriaRepository = new ProductoCategoriaRepository(statement);


            this.ProductoMarcaRepository = new ProductoMarcaRepository(statement);
            this.ProductoUnidadMedidaRepository = new ProductoUnidadMedidaRepository(statement);
            this.ProductoFileRepository = new ProductoFileRepository(statement);
            this.MarcaSucursalRepository = new MarcaSucursalRepository(statement);


            
        }

        public IAtencionProveedorRepository AtencionProveedorRepository { get; private set; }

        public IAlmacenesRepository AlmacenesRepository { get; private set; }

        public IClientesRepository ClientesRepository { get; private set; }

        public IComprasRepository ComprasRepository { get; private set; }

        public ICompraDetalleRepository CompraDetalleRepository { get; private set; }

        public IProductoStockRepository ProductoStockRepository { get; private set; }

        public IProductoRepository ProductoRepository { get; private set; }

        public IProveedoresRepository ProveedoresRepository { get; private set; }

        public IVentasRepository VentasRepository { get; private set; }

        public IVentasDetalleRepository VentasDetalleRepository { get; private set; }

        public ISucursalesRepository SucursalesRepository { get; private set; }

        public IUsuariosRepository UsuariosRepository { get; private set; }

        public IUsuarioSucursalRepository UsuarioSucursalRepository { get; private set; }

        public IUsuariosFileRepository UsuariosFileRepository { get; private set; }

        public ISucursalesFileRepository SucursalesFileRepository { get; private set; }

        public IEmpresaRepository  EmpresaRepository { get; private set; }

        public IAlmacenesFileRepository AlmacenesFileRepository { get; private set; }

        public IProductoCategoriaRepository ProductoCategoriaRepository { get; private set; }

        public IProductoMarcaRepository ProductoMarcaRepository { get; private set; }

        public IProductoUnidadMedidaRepository ProductoUnidadMedidaRepository { get; private set; }

        public IProductoFileRepository ProductoFileRepository { get; private set; }

        public IMarcaSucursalRepository MarcaSucursalRepository { get; private set; }
    }
}
