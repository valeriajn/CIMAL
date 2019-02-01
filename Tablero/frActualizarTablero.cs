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
    public partial class frActualizarTablero : Form
    {
        public frActualizarTablero()
        {
            InitializeComponent();
        }
        Clases.Tablero tab = new Clases.Tablero();
        Validar val = new Validar();
        public int id;
        private void frActualizarTablero_Load(object sender, EventArgs e)
        {
            Cargardatos();
        }
        private void Cargardatos()
        {
            try
            {
                foreach (DataRow fila in tab.CargarTablerosid(id).Rows)
                {

                    txtNombre.Text = fila[1].ToString();
                    txtPrecio.Text = fila[2].ToString();
                    txtColor.Text = fila[3].ToString();
                    txtDimension.Text = fila[4].ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

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
            tab.ID = id;
            tab.Nombre = txtNombre.Text;
            tab.Precio = Convert.ToDecimal(txtPrecio.Text.Replace(',', '.'));
            tab.Color = txtColor.Text;
            tab.Dimensiones = txtDimension.Text;

            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Verificar())
                {
                    return;
                }
                if (Validar())
                {
                    tab.ActualizarTablero();
                    MessageBox.Show("Registrado");
                }
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
