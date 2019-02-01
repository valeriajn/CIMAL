using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cimal.Personal
{
    public partial class frListarPersonal : Form
    {
        public frListarPersonal()
        {
            InitializeComponent();
        }
        Clases.Persona per = new Clases.Persona();
        int id;
        private void frListarPersonal_Load(object sender, EventArgs e)
        {
            Cargardatos();
        }
        private void Cargardatos()
        {
            try
            {
                dgvCargo.Rows.Clear();
                foreach (DataRow fila in per.CargarPersonaPersonal().Rows)
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
                    id = Convert.ToInt32(dgvCargo.CurrentRow.Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Personal.frGuardarPersonal f = new Personal.frGuardarPersonal();
            f.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frActualizarPersonal f = new frActualizarPersonal();
            f.id = this.id;
            f.ShowDialog();
            Cargardatos();
        }
    }
}
