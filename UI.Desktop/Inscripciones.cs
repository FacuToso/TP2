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
    public partial class Inscripciones : Form
    {
        public Inscripciones()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            AlumnoInscripcionLogic alumnoInscripcionLogic = new AlumnoInscripcionLogic();
            this.dgvInscripciones.AutoGenerateColumns = false;
            this.dgvInscripciones.DataSource = alumnoInscripcionLogic.GetAll();
        }

        private void Inscripciones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            InscripcionesDesktop inscripcionesDesktop = new InscripcionesDesktop(ApplicationForm.ModoForm.Alta);
            inscripcionesDesktop.ShowDialog();
            Listar();               
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
            InscripcionesDesktop inscripcionesDesktop = new InscripcionesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            inscripcionesDesktop.ShowDialog();
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.Rows.Count > 1)
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                InscripcionesDesktop inscripcionesDesktop = new InscripcionesDesktop(ID, ApplicationForm.ModoForm.Baja);
                inscripcionesDesktop.ShowDialog();
                Listar();
            }
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
