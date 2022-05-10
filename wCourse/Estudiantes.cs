using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace wCourse
{
    public partial class frmHijo : Form
    {
        public frmHijo()
        {
            InitializeComponent();

            cmbRH.Items.Add("O-");
            cmbRH.Items.Add("O+");
            cmbRH.Items.Add("A-");
            cmbRH.Items.Add("A+");
            cmbRH.Items.Add("B-");
            cmbRH.Items.Add("B+");
            cmbRH.Items.Add("AB-");
            cmbRH.Items.Add("AB+");
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Stream mystream;
        int counter = 0;
        String Line;

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Codigo curso";
            col1.Width = 200;
            col1.ReadOnly = true;
            dtgCVS.Columns.Add(col1);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Nombre curso";
            col2.Width = 200;
            col2.ReadOnly = true;
            dtgCVS.Columns.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Categoria curso";
            col3.Width = 200;
            col3.ReadOnly = true;
            dtgCVS.Columns.Add(col3);

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "Tema";
            col4.Width = 200;
            col4.ReadOnly = true;
            dtgCVS.Columns.Add(col4);

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Observaciones";
            col5.Width = 200;
            col5.ReadOnly = true;
            dtgCVS.Columns.Add(col5);

            char delimitador = ';';
            string[] valores;


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Archivos (*.CSV) | *.CSV";

            if ((openFileDialog.ShowDialog()) == DialogResult.OK)
                try
                {
                    if ((mystream = openFileDialog.OpenFile()) != null)
                    {
                        System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);

                        while ((Line = file.ReadLine()) != null)
                        {
                            if (counter >= 1)
                            {
                                valores = Line.Split(delimitador);

                                dtgCVS.Rows.Add(valores.ToArray());
                                counter++;
                            }
                            else
                            {
                                counter++;
                            }
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var clsDate = new clsDate();

            clsDate.Nombre = txtNombre.Text;
            clsDate.Apellido = txtApellido.Text;
            clsDate.Direccion = txtDireccion.Text;
            clsDate.Ciudad = txtCiudad.Text;
            clsDate.Comuna = txtComuna.Text;
            clsDate.Telefono = txtTelefono.Text;
            clsDate.RH = cmbRH.Text;

            MessageBox.Show($"Servicio de información\r\r\r Datos Personales: \r\r Nombre: {clsDate.Nombre} \r Apellido: {clsDate.Apellido} \r Direccion: {clsDate.Direccion} \r Ciudad: {clsDate.Ciudad} \r Telefono: {clsDate.Telefono} \r Tipo de sangre: {clsDate.RH}\r\r\r");
        }

        private void btnCargarTxt_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Archivos (*.CSV) | *.CSV";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((mystream = openFileDialog.OpenFile()) != null)
                    {
                        using (mystream)
                        {
                            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);

                            while ((Line = file.ReadLine()) != null)
                            {

                                txtLinea.Text = txtLinea.Text + Line;
                                counter++;
                            }

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
    

