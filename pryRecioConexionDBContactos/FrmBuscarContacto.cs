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
    public partial class FrmBuscarContacto : Form
    {
        public FrmBuscarContacto()
        {
            InitializeComponent();
        }


        ClsConexionBD conexionBD = new ClsConexionBD();


        private void FrmBuscarContacto_Load(object sender, EventArgs e)
        {
            conexionBD.ConectarBD();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string correo = txtCorreo.Text.Trim();

            string query = "SELECT Nombre, Apellido, Telefono, Correo, Categoria FROM Contactos WHERE 1=1";

            if (nombre != "")
                query += " AND Nombre LIKE @nombre";
            if (telefono != "")
                query += " AND Telefono LIKE @telefono";
            if (correo != "")
                query += " AND Correo LIKE @correo";

            OleDbCommand cmd = new OleDbCommand(query, conexionBD.conexion);

            if (nombre != "")
                cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
            if (telefono != "")
                cmd.Parameters.AddWithValue("@telefono", "%" + telefono + "%");
            if (correo != "")
                cmd.Parameters.AddWithValue("@correo", "%" + correo + "%");

            OleDbDataAdapter adaptador = new OleDbDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dgvResultados.DataSource = tabla;
        }

        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMenu fp = new FrmMenu();
            fp.Show();
            this.Hide();
        }
    }
}
