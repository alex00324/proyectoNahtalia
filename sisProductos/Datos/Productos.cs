using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
namespace sisProductos.Datos
{
    public class Productos
    {
        public int id_producto { get; set; }
        public String nombre { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }

        public Productos() { }

        public Productos(int pIdProducto,String pNombre,int pCantidad,int pPrecio) 
        {
            this.id_producto = pIdProducto;
            this.nombre = pNombre;
            this.cantidad = pCantidad;
            this.precio = pPrecio;
        }
        // Metodos CRUD
        public void InsertarProductos(MySqlConnection conexion, TextBox txtNombre, TextBox txtCantidad, TextBox txtPrecio)
        {
            conexion.Open();
            string Query = "Insert into productos (nombre,cantidad,precio) values ('" + txtNombre.Text +
                "','" + txtCantidad.Text + "','" + txtPrecio.Text + "');";

            MySqlCommand comando = new MySqlCommand(Query, conexion);

            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("se Inserto el producto " + txtNombre.Text);
            
        }

        public void ActualizarProductos(MySqlConnection conexion, TextBox txtIdproducto, TextBox txtNombre, TextBox txtCantidad, TextBox txtPrecio)
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

        }
        public void EliminarProductos(MySqlConnection conexion,TextBox txtIdproducto)
        {

            string Query = "Delete from productos where id_productos='" + txtIdproducto.Text + "';";
            conexion.Open();
            MySqlCommand comando = new MySqlCommand(Query, conexion);

            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("se Elimino el producto ");

        }
        public void ListarProductos(MySqlConnection conexion,DataGridView dataGridProductos)
        {
            conexion.Open();
            String Query = "Select * from productos";
            MySqlCommand comando = new MySqlCommand(Query, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            dataGridProductos.DataSource = tabla;
            conexion.Close();

        }
        // sumar un ingreso o restar
        public void RestarProductos(MySqlConnection conexion, TextBox txtIdproducto, TextBox txtCantidad, TextBox txtRestar)
        {
            
            int resultado = (txtRestar.Text == string.Empty) ? int.Parse(txtCantidad.Text) - 1 :
                resultado = int.Parse(txtCantidad.Text) - int.Parse(txtRestar.Text);

            string Query = "Update productos set cantidad='" + resultado.ToString() +
                "'where id_productos='" + txtIdproducto.Text +
                "';";
            conexion.Open();
            MySqlCommand comando = new MySqlCommand(Query, conexion);

            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("se Actualizo el producto " + txtIdproducto.Text);

        }







    }
}
