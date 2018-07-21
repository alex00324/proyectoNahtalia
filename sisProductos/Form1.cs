using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sisProductos
{
    public partial class Form1 : Form
    {
        Datos.Conexion conexion = new Datos.Conexion();
        Datos.Productos productos = new Datos.Productos();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                this.productos.ListarProductos(conexion.conexion, dataGridProductos);

            }
            catch(MySql.Data.MySqlClient.MySqlException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
      
            
        private void Limpiar()
        {
            this.txtIdproducto.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtRestar.Text = string.Empty;

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.productos.InsertarProductos(conexion.conexion,txtNombre,txtCantidad,txtPrecio);
            this.productos.ListarProductos(conexion.conexion, dataGridProductos);
            this.Limpiar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            this.productos.ActualizarProductos(conexion.conexion,txtIdproducto ,txtNombre, txtCantidad, txtPrecio);
            this.productos.ListarProductos(conexion.conexion, dataGridProductos);
            this.Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.productos.EliminarProductos(conexion.conexion, txtIdproducto);
            this.productos.ListarProductos(conexion.conexion, dataGridProductos);
            this.Limpiar();
        }

        private void dataGridProductos_Click(object sender, EventArgs e)
        {
            this.txtIdproducto.Text = Convert.ToString(this.dataGridProductos.CurrentRow.Cells["id_productos"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataGridProductos.CurrentRow.Cells["nombre"].Value);
            this.txtCantidad.Text = Convert.ToString(this.dataGridProductos.CurrentRow.Cells["cantidad"].Value);
            this.txtPrecio.Text = Convert.ToString(this.dataGridProductos.CurrentRow.Cells["precio"].Value);
              
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            
            this.productos.RestarProductos(conexion.conexion, txtIdproducto,txtCantidad,txtRestar);
            this.productos.ListarProductos(conexion.conexion, dataGridProductos);
            this.Limpiar();
        }
    }
}
