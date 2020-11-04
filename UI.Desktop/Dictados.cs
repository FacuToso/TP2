using Business.Logic;
using Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Dictados : Form
    {
        public Dictados()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            DocenteCursoLogic docenteCursoLogic = new DocenteCursoLogic();
            dgvDictados.AutoGenerateColumns = false;
            dgvDictados.DataSource = docenteCursoLogic.GetAll();
        }

        private void Dictados_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DictadosDesktop dictadosDesktop = new DictadosDesktop(ApplicationForm.ModoForm.Alta);
            dictadosDesktop.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.DocenteCurso)this.dgvDictados.SelectedRows[0].DataBoundItem).ID;            
            DictadosDesktop dictadosDesktop = new DictadosDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            dictadosDesktop.ShowDialog();
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvDictados.Rows.Count > 1)
            {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDictados.SelectedRows[0].DataBoundItem).ID;
                DictadosDesktop dictadosDesktop = new DictadosDesktop(ID, ApplicationForm.ModoForm.Baja);
                dictadosDesktop.ShowDialog();
                Listar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
