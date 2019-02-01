using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cimal.Clases;
using Cimal.LoginPermisos;
namespace Cimal
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            if (login.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                this.Close();
                this.Dispose();
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente.ListarClientes f = new Cliente.ListarClientes();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Personal.frListarPersonal f = new Personal.frListarPersonal();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tablero.ListarTablero f = new Tablero.ListarTablero();
            f.ShowDialog();
        }
    }
}
