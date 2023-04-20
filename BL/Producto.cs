using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezExamenPracticoEnITmaEntities contex = new DL.JRodriguezExamenPracticoEnITmaEntities())
                {
                    var query = contex.sp_InsCatalogoProd(producto.Descripcion);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezExamenPracticoEnITmaEntities contex = new DL.JRodriguezExamenPracticoEnITmaEntities())
                {
                    var query = contex.UpdateCatalogoProd(producto.IdProducto, producto.Descripcion);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezExamenPracticoEnITmaEntities contex = new DL.JRodriguezExamenPracticoEnITmaEntities())
                {
                    var query = contex.GetAllCatalogoProd().ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = item.IdProducto;
                            producto.Descripcion = item.Descripción;
                            producto.IdUsuario = item.IdUsuario.Value;
                            producto.FechaCreacion = item.FechaCreacion.Value.ToString("dd/MM/yyyy");

                            result.Objects.Add(producto);
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezExamenPracticoEnITmaEntities contex = new DL.JRodriguezExamenPracticoEnITmaEntities())
                {
                    var query = contex.GetByIdCatalogoProd(IdProducto).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Producto producto = new ML.Producto();
                        producto.IdProducto = query.IdProducto;
                        producto.Descripcion = query.Descripción;
                        producto.IdUsuario = query.IdUsuario.Value;
                        producto.FechaCreacion = query.FechaCreacion.Value.ToString("dd/MM/yyyy");
                        result.Object = producto;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
    }
}
