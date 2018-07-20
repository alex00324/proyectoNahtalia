using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace sisProductos.Datos
{
    public class Conexion
    {
        public MySqlConnection conexion;
        public Conexion()
        {
            conexion = new MySqlConnection("Server=localhost;port=3306;Database=productos;Uid=root;pwd=;SslMode=None"); 
     
        }
        
    }
}
