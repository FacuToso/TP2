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
    public partial class Personas : Form
    {
        public Personas()
        {
            InitializeComponent();
        }
        public void Listar()
        {
            PersonasLogic personasLogic = new PersonasLogic();
            this.dgvPersonas.AutoGenerateColumns = false;
            this.dgvPersonas.DataSource = personasLogic.GetAll();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop personaDesktop = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            personaDesktop.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonaDesktop formusper = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formusper.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.Rows.Count > 1)
            {
                int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop formusuario = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formusuario.ShowDialog();
                this.Listar();
            }
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
