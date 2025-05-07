using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecioConexionDBContactos
{
    
    public class ClsConexionBD
    {
        private string cadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\TecnoBaires\Desktop\DBContactos.mdb;";

        private OleDbConnection conexionBD;

        public OleDbConnection conexion
        {
            get { return conexionBD; }
        }

        public void ConectarBD()
        {
            try
            {
                conexionBD = new OleDbConnection(cadenaConexion);
                conexionBD.Open();
                MessageBox.Show("✅ Conectado a la base de datos.");
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("❌ Error al conectar: " + ex.Message);
            }
        }
    }
}
