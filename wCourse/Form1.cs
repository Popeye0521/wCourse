using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Autores: Juan Manuel Torres Maguirre, Jjpope Julian Berrio Uribe y Zlatan David Ramos Calzada
/// Fecha: Lunes 9 - mayo / 2022
/// Descripción: Carga de datos de una tabla (txt y CVS)
/// </summary>

namespace wCourse
{
    public partial class FrmPadre : Form
    {
        public FrmPadre()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHijo frmHijo = new frmHijo();
            frmHijo.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            Form frmPadre = this.ActiveMdiChild;
            if (frmPadre != null)
            {
                frmPadre.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
