using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

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
        //public static int AgregarProducto()
        //{
         
        //}
        //public static int ActualizarProducto()
        //{

        //}
        //public static int EliminarProducto()
        //{

        //}




    }
}
