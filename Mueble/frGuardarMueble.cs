using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cimal.Mueble
{
    public partial class frGuardarMueble : Form
    {
        public frGuardarMueble()
        {
            InitializeComponent();
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Abrir = new OpenFileDialog();
            Abrir.Filter = "*.bmp;*.jpg;*.png|*.bmp;*.gif;*.jpg;*.png ";
            Abrir.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            Abrir.Title = "Seleccione una Imagen";
            Abrir.RestoreDirectory = true;
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                lblruta.Text = Abrir.FileName;
                txtNombre.Text = Abrir.SafeFileName;
                pictureBox1.Image = Image.FromFile(Abrir.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                lblruta.Text = "";
                pictureBox1.Image = null;
            }
        }
       
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!Verificar())
            //    {
            //        return;
            //    }
            //    if (Validar())
            //    {
            //        tab.GuardarTablero();
            //        MessageBox.Show("Registrado");
            //    }
            //    this.Close();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.ToString());
            //}
        }
    }
}
