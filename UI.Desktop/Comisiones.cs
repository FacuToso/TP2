using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            ComisionLogic com = new ComisionLogic();
            this.dgvComisiones.AutoGenerateColumns = false;
            this.dgvComisiones.DataSource = com.GetAll();
        }

        #region Eventos
        private void Comisiones_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop formespecialidad = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formespecialidad.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formesp = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formesp.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formesp = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
            formesp.ShowDialog();
            this.Listar();
        }
        #endregion


    }
}
