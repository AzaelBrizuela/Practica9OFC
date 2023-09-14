using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Entidades.Practica9;
using AccesoDatos.Practica9;

namespace AccesoDatos.Practica9
{
    public class ProductosAccesoDatos
    {
        Conexion conexion;
        public ProductosAccesoDatos()
        {
            conexion = new Conexion("localhost", "root", "", "TIENDA_", 3306);
        }
        public List<Productos> ObtenerProductos()
        {
            var ListaProductos = new List<Productos>();
            var dt = new DataTable();
            dt = conexion.ObtenerDatos("Select * from datos_producto_;");
            foreach (DataRow renglon in dt.Rows)
            {
                var productos = new Productos
                {
                    Id = Convert.ToInt32(renglon["id_producto"]),
                    Nombre = renglon["nombre"].ToString(),
                    Descripcion = renglon["descripcion"].ToString(),
                    Precio = Convert.ToDouble(renglon["precio"]),
                };
                ListaProductos.Add(productos);
            }
            return ListaProductos;
        }
        public void GuardarProducto(Productos nuevoproducto)
        {
            string Consulta = string.Format("Insert Into datos_producto_ values(null,'{0}','{1}','{2}');",
                nuevoproducto.Nombre, nuevoproducto.Descripcion, nuevoproducto.Precio);
            conexion.EjecutarConsulta(Consulta);
        }



        public List<Productos> BuscarProductos(string valor)
        {
            var ListaProductos = new List<Productos>();
            var dt = new DataTable();
            var consulta = string.Format("Select * from datos_producto_ where nombre like '%{0}%'", valor);
            dt = conexion.ObtenerDatos(consulta);
            foreach (DataRow renglon in dt.Rows)
            {
                var producto = new Productos
                {
                    Id = Convert.ToInt32(renglon["id_producto"]),
                    Nombre = renglon["nombre"].ToString(),
                    Descripcion = renglon["descripcion"].ToString(),
                    Precio = Convert.ToDouble(renglon["precio"]),
                };
                ListaProductos.Add(producto);
            }
            return ListaProductos;
        }




        public void EliminarProductos(int idproducto)
        {
            string consulta = string.Format("delete from datos_producto_ where id_producto ={0}", idproducto);
            conexion.EjecutarConsulta(consulta);
        }
        public void ActualizarProductos(Productos nuevoproducto)
        {
            string consulta = string.Format("update datos_producto_ set nombre='{0}',descripcion='{1}',precio='{2}'",
                                            nuevoproducto.Nombre, nuevoproducto.Descripcion, nuevoproducto.Precio);
            conexion.EjecutarConsulta(consulta);
        }
    }
}
