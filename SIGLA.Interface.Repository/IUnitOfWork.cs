using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Interface.Repository
{
    public interface IUnitOfWork
    {
        IAtencionProveedorRepository AtencionProveedorRepository { get; }



        IAlmacenesRepository AlmacenesRepository { get; }

        IClientesRepository ClientesRepository { get; }

        IComprasRepository ComprasRepository { get; }

        ICompraDetalleRepository CompraDetalleRepository { get; }

        IProductoStockRepository ProductoStockRepository { get; }
        IProductoRepository ProductoRepository { get; }


        IProveedoresRepository ProveedoresRepository { get; }

        IVentasRepository VentasRepository { get; }


        IVentasDetalleRepository VentasDetalleRepository { get; }
        ISucursalesRepository SucursalesRepository { get; }
        IUsuariosRepository UsuariosRepository { get; }
        IUsuarioSucursalRepository UsuarioSucursalRepository { get; }

        IUsuariosFileRepository  UsuariosFileRepository { get; }
        ISucursalesFileRepository  SucursalesFileRepository { get; }
        IEmpresaRepository  EmpresaRepository { get; }

        IAlmacenesFileRepository  AlmacenesFileRepository { get; }





        IProductoCategoriaRepository  ProductoCategoriaRepository { get; }
        IProductoMarcaRepository  ProductoMarcaRepository { get; }
        IProductoUnidadMedidaRepository  ProductoUnidadMedidaRepository { get; }


        IProductoFileRepository  ProductoFileRepository { get; }

        IMarcaSucursalRepository  MarcaSucursalRepository { get; }

    }

}
