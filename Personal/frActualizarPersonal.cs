using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cimal.Clases;
namespace Cimal.Personal
{
    public partial class frActualizarPersonal : Form
    {
        public frActualizarPersonal()
        {
            InitializeComponent();
        }
        Usuario user = new Usuario();
        Persona persona = new Persona();
        Validar val = new Validar();
        public int id;
        private bool Verificar()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Inserte un nombre correcto");
                return false;
            }
            if (txtApellido.Text == "")
            {
                MessageBox.Show("Inserte un apellido correcto");
                return false;
            }
            if (txtNit.Text == "")
            {
                txtNit.Text = "0";
            }
            if (txtCedula.Text == " ")
            {
                txtCedula.Text = "0";
            }
            if (txtLogin.Text == " ")
            {
                MessageBox.Show("Inserte un nombre de usuario /Login correcto");
                return false;
            }
            if (txtPassword.Text == " ")
            {
                MessageBox.Show("Inserte un Password correcto");
                return false;
            }
            return true;
        }
        private bool Validar()
        {
            persona.ID = id;
            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.Nit = txtNit.Text;
            persona.CI = txtCedula.Text;
            persona.Direccion = txtDireccion.Text;
            persona.Correo = txtCorreo.Text;
            persona.Telefono = txtTelefono.Text;
            user.ID = persona.ID;
            user.Login = txtLogin.Text;
            user.Password = txtPassword.Text;

            return true;
        }
        private void Cargardatos()
        {
            try
            {
                foreach (DataRow fila in persona.CargarPersonalid(id).Rows)
                {

                    txtNombre.Text = fila[1].ToString();
                    txtApellido.Text = fila[2].ToString();
                    txtNit.Text = fila[3].ToString();
                    txtCedula.Text = fila[4].ToString();
                    txtDireccion.Text = fila[5].ToString();
                    txtCorreo.Text = fila[6].ToString();
                    txtTelefono.Text = fila[7].ToString();
                    txtLogin.Text = fila[8].ToString();
                    txtPassword.Text = fila[9].ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

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
                    persona.ActualizarPersona();

                    user.ActualizarUsuario();
                    MessageBox.Show("Registrado");
                }
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frActualizarPersonal_Load(object sender, EventArgs e)
        {
            Cargardatos();
        }
    }
}
