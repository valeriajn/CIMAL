using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cimal.Tablero
{
    public partial class frGuardarTablero : Form
    {
        public frGuardarTablero()
        {
            InitializeComponent();
        }
        Clases.Tablero tab = new Clases.Tablero();
        Validar val = new Validar();
        private void frGuardarTablero_Load(object sender, EventArgs e)
        {

        }
        private bool Verificar()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Inserte un nombre correcto");
                return false;
            }
            if (txtDimension.Text == "")
            {
                MessageBox.Show("Inserte una Dimension correcta");
                return false;
            }
            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Inserte un Precio correcto");
                return false;
            }
            if (txtColor.Text == " ")
            {
                MessageBox.Show("Inserte un Color correcto");
                return false;
            }
          
            return true;
        }
        private bool Validar()
        {
            tab.ID = tab.IDTableroMax();
            tab.Nombre = txtNombre.Text;
            tab.Precio = Convert.ToDecimal(txtPrecio.Text.Replace(',', '.'));
            tab.Color = txtColor.Text;
            tab.Dimensiones = txtDimension.Text;

            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                if (!Verificar())
                {
                    return;
                }
                if (Validar())
                {
                    tab.GuardarTablero();
                    MessageBox.Show("Registrado");
                }
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtDimension_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
