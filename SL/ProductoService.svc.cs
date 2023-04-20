using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductoService.svc or ProductoService.svc.cs at the Solution Explorer and start debugging.
    public class ProductoService : IProductoService
    {
        public ML.Result Add(ML.Producto producto)
        {
            ML.Result result = BL.Producto.Add(producto);

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public ML.Result Update(ML.Producto producto)
        {
            ML.Result result = BL.Producto.Update(producto);

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public ML.Result GetAll()
        {
            ML.Result result = BL.Producto.GetAll();

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public ML.Result GetById(int IdProducto)
        {
            ML.Result result = BL.Producto.GetById(IdProducto);

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
