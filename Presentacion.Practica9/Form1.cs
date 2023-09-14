using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio.Practica9;
using Entidades.Practica9;

namespace Presentacion.Practica9
{
    public partial class Form1 : Form
    {
        private int idproducto = 0;
        private ProductosLogica _productoslogica;
        public Form1()
        {
            InitializeComponent();
            _productoslogica = new ProductosLogica();
        }
        private void LlenarDatos()
        {
            dtgDatosTabla.DataSource = _productoslogica.ObtenerProductos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarDatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Productos _nuevoproducto = new Productos();
            _nuevoproducto.Nombre = txtNombre.Text;
            _nuevoproducto.Descripcion = txtDescripcion.Text;
            _nuevoproducto.Precio = double.Parse( txtPrecio.Text);
            var validar = _productoslogica.ValidarProductos(_nuevoproducto);
            if (validar.Item1)
            {
                _productoslogica.GuardarProducto(_nuevoproducto);
                LlenarDatos();
                LimpiarTexto();
            }
            else
                MessageBox.Show(validar.Item2,"Error de campos",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void LimpiarTexto()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Eliminar();
            LlenarDatos();
        }
        private void Eliminar()
        {
            if (MessageBox.Show("estas segur@ que Deseas eliminar a este Producto", "Eliminar Producto", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var idproducto = int.Parse(dtgDatosTabla.CurrentRow.Cells["id"].Value.ToString());
                _productoslogica.EliminarProducto(idproducto);
            }
        }

        private void dtgDatosTabla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = dtgDatosTabla.CurrentRow.Cells["nombre"].Value.ToString();
            txtDescripcion .Text = dtgDatosTabla.CurrentRow.Cells["descripcion"].Value.ToString();
            txtPrecio.Text = dtgDatosTabla.CurrentRow.Cells["precio"].Value.ToString();
            idproducto = int.Parse(dtgDatosTabla.CurrentRow.Cells["id"].Value.ToString());
        }
        private void ModificacionProductos()
        {
            Productos nuevoproducto = new Productos();
            nuevoproducto.Id = idproducto;
            nuevoproducto.Nombre = txtNombre .Text;
            nuevoproducto.Descripcion = txtDescripcion.Text;
            nuevoproducto.Precio = double.Parse(txtPrecio.Text);
            var validar = _productoslogica.ValidarProductos(nuevoproducto);
            if (validar.Item1)
            {
                _productoslogica.ActualizarProductos(nuevoproducto);
                LlenarDatos();
                LimpiarTexto ();
                txtNombre.Focus();
            }
            else
                MessageBox.Show(validar.Item2, "Error de Campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ModificacionProductos();
        }
    }
}
