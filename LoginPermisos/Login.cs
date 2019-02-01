using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cimal.Clases;

namespace Cimal.LoginPermisos
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Usuario log = new Usuario();
        private void btnIngresar_Click(object sender, EventArgs e)  
        {
            try
            {
                log.Login = txtUsuario.Text;
                log.Password = txtContrasena.Text;
                int id = log.Loguearse();
                if (id == -1)
                {
                    MessageBox.Show("Usuario y/o Contraseña erronea!!", "Credenciales erroeneas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente.frGuardarCliente f = new Cliente.frGuardarCliente();
            f.ShowDialog();
        }
    }
}
