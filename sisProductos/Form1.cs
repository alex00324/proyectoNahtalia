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
               
                  this.ListarProductos(conexion.conexion);
                

            }
            catch(MySql.Data.MySqlClient.MySqlException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        
            
        public void ListarProductos(MySqlConnection conexion)
        {
            conexion.Open();
            String Query = "Select * from productos" ;
            MySqlCommand comando = new MySqlCommand(Query, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            dataGridProductos.DataSource = tabla;
            conexion.Close();
            
        }
        public void InsertarProductos(MySqlConnection conexion)
        {
            conexion.Open();
            string Query = "Insert into productos (nombre,cantidad,precio) values ('" + txtNombre.Text +
                "','" + txtCantidad.Text + "','" + txtPrecio.Text + "');";
            
            MySqlCommand comando = new MySqlCommand(Query, conexion);

            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("se Inserto el producto " + txtNombre.Text);
            this.ListarProductos(conexion);
        }
        public void ActualizarProductos(MySqlConnection conexion)
        {

            string Query = "Update productos set id_productos='" + txtIdproducto.Text +
                "',nombre= '" + txtNombre.Text +
                "',cantidad='" + txtCantidad.Text +
                "',precio='" + txtPrecio.Text +
                "'where id_productos='" + txtIdproducto.Text +
                "';";
            conexion.Open();
            MySqlCommand comando = new MySqlCommand(Query, conexion);

            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("se Actualizo el producto " + txtNombre.Text);
            this.ListarProductos(conexion);
        }
        public void EliminarProductos(MySqlConnection conexion)
        {

            string Query = "Delete from productos where id_productos='" + txtIdproducto.Text + "';";
            conexion.Open();
            MySqlCommand comando = new MySqlCommand(Query, conexion);

            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("se Elimino el producto ");
            this.ListarProductos(conexion);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            InsertarProductos(conexion.conexion);
           
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            ActualizarProductos(conexion.conexion);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarProductos(conexion.conexion);
        }
    }
}
