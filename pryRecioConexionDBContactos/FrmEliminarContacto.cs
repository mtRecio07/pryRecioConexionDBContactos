using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecioConexionDBContactos
{
    public partial class FrmEliminarContacto : Form
    {
        public FrmEliminarContacto()
        {
            InitializeComponent();
        }

        ClsConexionBD conexionBD = new ClsConexionBD();

        private void FrmEliminarContacto_Load(object sender, EventArgs e)
        {
            conexionBD.ConectarBD();
            CargarContactos();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();

            if (filtro == "")
            {
                MessageBox.Show("Ingresá un teléfono o correo para eliminar.");
                return;
            }

            // Verificamos si existe
            string verificar = "SELECT * FROM Contactos WHERE Telefono = @filtro OR Correo = @filtro";
            OleDbCommand cmdVerificar = new OleDbCommand(verificar, conexionBD.conexion);
            cmdVerificar.Parameters.AddWithValue("@filtro", filtro);

            OleDbDataReader reader = cmdVerificar.ExecuteReader();

            if (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                reader.Close();

                string delete = "DELETE FROM Contactos WHERE Id = @id";
                OleDbCommand cmdEliminar = new OleDbCommand(delete, conexionBD.conexion);
                cmdEliminar.Parameters.AddWithValue("@id", id);
                cmdEliminar.ExecuteNonQuery();

                MessageBox.Show("Contacto eliminado.");
                CargarContactos();
            }
            else
            {
                reader.Close();
                MessageBox.Show("Contacto no encontrado.");
            }

        }



        private void CargarContactos()
        {
            string query = "SELECT Nombre, Apellido, Telefono, Correo, Categoria FROM Contactos ORDER BY Apellido";
            OleDbDataAdapter adaptador = new OleDbDataAdapter(query, conexionBD.conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dgvContactos.DataSource = tabla;
        }

        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMenu fp = new FrmMenu();
            fp.Show();
            this.Hide();
        }
    }
}
