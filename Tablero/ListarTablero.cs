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
    public partial class ListarTablero : Form
    {
        public ListarTablero()
        {
            InitializeComponent();
        }
        Clases.Tablero tab = new Clases.Tablero();
        int id;
        private void ListarTablero_Load(object sender, EventArgs e)
        {
            Cargardatos();
        }
        private void Cargardatos()
        {
            try
            {
                dgvCargo.Rows.Clear();
                foreach (DataRow fila in tab.CargarTableros().Rows)
                {
                    dgvCargo.Rows.Add(fila[0].ToString(), fila[1].ToString(), fila[2].ToString(), (fila[3].ToString()), fila[4].ToString());
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
            frGuardarTablero f = new frGuardarTablero();
            f.ShowDialog();
            Cargardatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frActualizarTablero f = new frActualizarTablero();
            f.id = this.id;
            f.ShowDialog();
            Cargardatos();
        }
    }
}
