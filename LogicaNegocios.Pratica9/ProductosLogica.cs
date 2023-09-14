using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Practica9;
using AccesoDatos.Practica9;

namespace LogicaNegocio.Practica9
{
    public class ProductosLogica
    {
        private ProductosAccesoDatos _productosaccesodatos;
        public ProductosLogica()
        {
            _productosaccesodatos = new ProductosAccesoDatos();
        }
        public List<Productos> ObtenerProductos()
        {
            return _productosaccesodatos.ObtenerProductos();
        }
        public List<Productos> BuscarProductos(string valor)
        {
            return _productosaccesodatos.BuscarProductos(valor);
        }
        public void GuardarProducto(Productos nuevoproducto)
        {
            _productosaccesodatos.GuardarProducto(nuevoproducto);
        }
        public void ActualizarProductos(Productos productos)
        {
            _productosaccesodatos.ActualizarProductos(productos);
        }
        public void EliminarProducto(int idproducto)
        {
            _productosaccesodatos.EliminarProductos(idproducto);
        }
        public Tuple<bool, string> ValidarProductos(Productos nuevoproducto)
        {
            string mensaje = "";
            bool valida = true;
            if (nuevoproducto.Nombre == "")
            {
                mensaje = mensaje + "El Campo nombre es Reqerido \n";
                valida = false;
            }
            if (nuevoproducto.Descripcion == "")
            {
                mensaje = mensaje + "El Campo descripcion es Reqerido \n";
                valida = false;
            }

            if (nuevoproducto.Precio.ToString() == "")
            {
                mensaje = mensaje + "El Campo precio es Reqerido \n";
                valida = false;
            }

            var validar = new Tuple<bool, string>(valida, mensaje);
            return validar;
        }
    }
}