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
    public partial class FrmEditarContacto : Form
    {
        public FrmEditarContacto()
        {
            InitializeComponent();
        }


        ClsConexionBD conexionBD = new ClsConexionBD();
        int idContacto = -1;

        private void FrmEditarContacto_Load(object sender, EventArgs e)
        {
            conexionBD.ConectarBD();

            cboCategoria.Items.Add("Familia");
            cboCategoria.Items.Add("Trabajo");
            cboCategoria.Items.Add("Amigos");

            CargarContactos(); // Mostrar todos al cargar
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();

            if (filtro == "")
            {
                MessageBox.Show("Ingresá un teléfono o correo para buscar.");
                return;
            }

            string query = "SELECT * FROM Contactos WHERE Telefono = @filtro OR Correo = @filtro";
            OleDbCommand cmd = new OleDbCommand(query, conexionBD.conexion);
            cmd.Parameters.AddWithValue("@filtro", filtro);

            OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                idContacto = Convert.ToInt32(reader["Id"]);
                txtNombre.Text = reader["Nombre"].ToString();
                txtApellido.Text = reader["Apellido"].ToString();
                txtTelefono.Text = reader["Telefono"].ToString();
                txtCorreo.Text = reader["Correo"].ToString();
                cboCategoria.SelectedItem = reader["Categoria"].ToString();
            }
            else
            {
                MessageBox.Show("Contacto no encontrado.");
            }

            reader.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idContacto == -1)
            {
                MessageBox.Show("Primero buscá un contacto.");
                return;
            }

            string updateQuery = "UPDATE Contactos SET Nombre=@nombre, Apellido=@apellido, Telefono=@telefono, Correo=@correo, Categoria=@categoria WHERE Id=@id";
            OleDbCommand cmd = new OleDbCommand(updateQuery, conexionBD.conexion);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@apellido", txtApellido.Text);
            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
            cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
            cmd.Parameters.AddWithValue("@categoria", cboCategoria.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@id", idContacto);

            cmd.ExecuteNonQuery();

            MessageBox.Show("✅ Contacto actualizado con éxito.");
            CargarContactos();
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
