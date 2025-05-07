using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecioConexionDBContactos
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEliminarContacto fp = new FrmEliminarContacto();
            fp.Show();
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmEditarContacto fp = new FrmEditarContacto();
            fp.Show();
            this.Hide();
        }

        private void agregarContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarContacto fp = new FrmAgregarContacto();
            fp.Show();
            this.Hide();
        }

        private void agendaDeContactosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgendaContactos fp = new FrmAgendaContactos();
            fp.Show();
            this.Hide();
        }
    }
}
