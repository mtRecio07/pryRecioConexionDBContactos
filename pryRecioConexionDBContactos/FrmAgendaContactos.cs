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
    public partial class FrmAgendaContactos : Form
    {
        public FrmAgendaContactos()
        {
            InitializeComponent();
        }



        ClsConexionBD conexionBD = new ClsConexionBD();


        private void FrmAgendaContactos_Load(object sender, EventArgs e)
        {
            conexionBD.ConectarBD();
            MostrarContactosEnTreeView();
        }



        private void MostrarContactosEnTreeView()
        {
            treeContactos.Nodes.Clear();

            string query = "SELECT Nombre, Apellido, CategoriaId FROM Contactos ORDER BY CategoriaId, Apellido";
            OleDbCommand cmd = new OleDbCommand(query, conexionBD.conexion);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string categoria = reader["CategoriaId"].ToString();
                string nombreCompleto = $"{reader["Apellido"]}, {reader["Nombre"]}";

                // Verificamos si ya existe el nodo de categoría
                TreeNode nodoCategoria;
                if (treeContactos.Nodes.ContainsKey(categoria))
                {
                    nodoCategoria = treeContactos.Nodes[categoria];
                }
                else
                {
                    nodoCategoria = treeContactos.Nodes.Add(categoria, categoria);
                }

                // Agregamos el contacto como subnodo
                nodoCategoria.Nodes.Add(nombreCompleto);
            }

            treeContactos.ExpandAll();
            reader.Close();
        }


        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMenu fp = new FrmMenu();
            fp.Show();
            this.Hide();
        }
    }
}
