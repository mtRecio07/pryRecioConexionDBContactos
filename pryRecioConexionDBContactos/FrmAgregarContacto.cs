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
    public partial class FrmAgregarContacto : Form
    {
        public FrmAgregarContacto()
        {
            InitializeComponent();
        }

        private void FrmAgregarContacto_Load(object sender, EventArgs e)
        {
            conexionBD.ConectarBD();

            cboCategoria.Items.Add("Familia");
            cboCategoria.Items.Add("Trabajo");
            cboCategoria.Items.Add("Amigos");

            CargarContactos(); // Mostrar contactos al cargar
        }


        ClsConexionBD conexionBD = new ClsConexionBD();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || cboCategoria.SelectedItem == null)
            {
                MessageBox.Show("⚠️ Completá todos los campos.");
                return;
            }

            try
            {
                string insertQuery = "INSERT INTO Contactos (Nombre, Apellido, Telefono, Correo, CategoriaId) VALUES (@Nombre, @Apellido, @Telefono, @Correo, @Categoria)";
                OleDbCommand cmd = new OleDbCommand(insertQuery, conexionBD.conexion);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@CategoriaId", cboCategoria.SelectedItem.ToString());

                cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Contacto agregado con éxito.");

                // Limpiar campos
                txtNombre.Clear();
                txtApellido.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                cboCategoria.SelectedIndex = -1;

                // Actualizar grilla
                CargarContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al agregar: " + ex.Message);
            }
        }


        private void CargarContactos()
        {
            try
            {
                string query = "SELECT Nombre, Apellido, Telefono, Correo, CategoriaId FROM Contactos ORDER BY Apellido";
                OleDbDataAdapter adaptador = new OleDbDataAdapter(query, conexionBD.conexion);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dgvContactos.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al cargar contactos: " + ex.Message);
            }
        }

        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMenu fp = new FrmMenu();
            fp.Show();
            this.Hide();
        }
    }
}
