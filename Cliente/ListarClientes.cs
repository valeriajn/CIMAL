using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cimal.Cliente
{
    public partial class ListarClientes : Form
    {
        public ListarClientes()
        {
            InitializeComponent();
        }
        Clases.Persona per = new Clases.Persona();
        public int id;
        private void ListarClientes_Load(object sender, EventArgs e)
        {
            Cargardatos();
        }
        private void Cargardatos()
        {
            try
            {
                dgvCargo.Rows.Clear();
                foreach (DataRow fila in per.CargarPersonaCliente().Rows)
                {
                    dgvCargo.Rows.Add(fila[0].ToString(), fila[1].ToString(), fila[2].ToString(), (fila[3].ToString()), fila[4].ToString(), (fila[5].ToString()), fila[6].ToString(), fila[7].ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void dgvCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCargo.CurrentRow != null)
                {
                    id = Convert.ToInt32( dgvCargo.CurrentRow.Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frGuardarCliente f = new frGuardarCliente();
            f.ShowDialog();
            Cargardatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frActualizarClientes f = new frActualizarClientes();
            f.id = this.id;
            f.ShowDialog();
            Cargardatos();
        }
    }
}
