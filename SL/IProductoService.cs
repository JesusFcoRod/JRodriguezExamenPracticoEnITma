using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductoService" in both code and config file together.
    [ServiceContract]
    public interface IProductoService
    {
        [OperationContract]
        ML.Result Add(ML.Producto producto);

        [OperationContract]
        ML.Result Update(ML.Producto producto);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))]
        ML.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))]
        ML.Result GetById(int IdProducto);

    }
}
