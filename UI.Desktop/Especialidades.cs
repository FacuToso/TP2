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
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
            //Hola
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.AutoGenerateColumns = false;
            this.dgvEspecialidades.DataSource = el.GetAll();
        }

        public void Especialidades_Load(object sender, EventArgs e)
        {
            Listar();
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
            EspecialidadDesktop formespecialidad = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            formespecialidad.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadDesktop formesp = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formesp.ShowDialog();
            this.Listar();
        }

        private void tsdEliminar_Click(object sender, EventArgs e)
        {
            if(this.dgvEspecialidades.Rows.Count > 1)
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop formesp = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
                formesp.ShowDialog();
                this.Listar();
            }
        }
    }
}
