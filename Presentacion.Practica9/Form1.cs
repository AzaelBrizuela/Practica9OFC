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
    }
}
