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
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            this.dgvPlanes.AutoGenerateColumns = false;
            this.dgvPlanes.DataSource = pl.GetAll();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop formplan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formplan.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop formplan = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formplan.ShowDialog();
            this.Listar();
        }

        private void tsdEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.Rows.Count > 1)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop formplan = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
                formplan.ShowDialog();
                this.Listar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}