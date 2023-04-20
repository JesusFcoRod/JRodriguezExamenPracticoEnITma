using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Producto producto= new ML.Producto();
            ProductoService.ProductoServiceClient productoService = new ProductoService.ProductoServiceClient();
            ML.Result result = productoService.GetAll();

            producto.Productos = result.Objects;

            return View(producto);
        }

        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            ML.Result result = new ML.Result();
            ML.Producto producto = new ML.Producto();

            if (IdProducto != null)
            {
                ProductoService.ProductoServiceClient productoService = new ProductoService.ProductoServiceClient();
                result = productoService.GetById(IdProducto.Value);

                if (result.Correct)
                {
                    producto = (ML.Producto)result.Object;
                    return View(producto);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar la informacion del producto";
                }
                return PartialView("Modal");
            }
            else
            {
                return View(producto);
            }
        }

        [HttpPost]

        public ActionResult Form(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            int IdProducto = producto.IdProducto;

            if (IdProducto > 0)
            {
                //UPDATE
                ProductoService.ProductoServiceClient productoService = new ProductoService.ProductoServiceClient();
                result = productoService.Update(producto);

                if (result.Correct)
                {
                    ViewBag.Message = "Producto actualizado con exito";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar los datos del Producto";
                }

            }
            else
            {
                //ADD
                ProductoService.ProductoServiceClient productoService = new ProductoService.ProductoServiceClient();
                result = productoService.Add(producto);

                if (result.Correct)
                {
                    ViewBag.Message = "Producto agregado con exito";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al agregar los datos del Producto";
                }
            }
            return PartialView("Modal");

        }
    }
}