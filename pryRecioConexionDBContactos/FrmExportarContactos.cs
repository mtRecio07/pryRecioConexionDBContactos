using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecioConexionDBContactos
{
    public partial class FrmExportarContactos : Form
    {
        public FrmExportarContactos()
        {
            InitializeComponent();
        }


        ClsConexionBD conexionBD = new ClsConexionBD();

        private void FrmExportarContactos_Load(object sender, EventArgs e)
        {
            conexionBD.ConectarBD();

        }

        private void btnExportarCSV_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Contactos";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, conexionBD.conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Archivo CSV|*.csv",
                    FileName = "Contactos.csv"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        // Encabezados
                        string[] columnNames = { "Nombre", "Apellido", "Telefono", "Correo", "Categoria" };
                        writer.WriteLine(string.Join(",", columnNames));

                        // Filas
                        foreach (DataRow row in tabla.Rows)
                        {
                            string linea = $"{row["Nombre"]},{row["Apellido"]},{row["Telefono"]},{row["Correo"]},{row["Categoria"]}";
                            writer.WriteLine(linea);
                        }
                    }

                    MessageBox.Show("✅ Contactos exportados a CSV correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al exportar CSV: " + ex.Message);
            }

        }

        private void btnExportarVCard_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Contactos";
                OleDbCommand cmd = new OleDbCommand(query, conexionBD.conexion);
                OleDbDataReader reader = cmd.ExecuteReader();

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Archivo vCard|*.vcf",
                    FileName = "Contactos.vcf"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        while (reader.Read())
                        {
                            writer.WriteLine("BEGIN:VCARD");
                            writer.WriteLine("VERSION:3.0");
                            writer.WriteLine($"N:{reader["Apellido"]};{reader["Nombre"]};;;");
                            writer.WriteLine($"FN:{reader["Nombre"]} {reader["Apellido"]}");
                            writer.WriteLine($"TEL:{reader["Telefono"]}");
                            writer.WriteLine($"EMAIL:{reader["Correo"]}");
                            writer.WriteLine("END:VCARD");
                        }
                    }

                    reader.Close();
                    MessageBox.Show("✅ Contactos exportados a vCard correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al exportar vCard: " + ex.Message);
            }

        }

        private void vOlverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMenu fp = new FrmMenu();
            fp.Show();
            this.Hide();
        }
    }
}
