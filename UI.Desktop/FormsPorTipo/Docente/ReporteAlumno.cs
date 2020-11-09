using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.FormsPorTipo.Docente
{
    public partial class ReporteAlumno : Form
    {
        Usuario Usuario
        {
            get; set;
        }
        public ReporteAlumno(Usuario user)
        {
            InitializeComponent();
            Usuario = user;
        }

        private void ReporteAlumno_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'academiaDataSet.alumnos_inscripciones' Puede moverla o quitarla según sea necesario.
            this.alumnos_inscripcionesTableAdapter.Fill(this.academiaDataSet.alumnos_inscripciones);
            RvInscripciones.LocalReport.ReportPath = @"C:\Users\Facu\Desktop\TP2 - master\UI.Desktop\FormsPorTipo\Docente\ReporteAlumnos.rdlc";
            RvInscripciones.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

            InscripcionBindingSource.DataSource = new AlumnoInscripcionLogic().GetAll(Usuario);

            ReportDataSource reportDataSource = new ReportDataSource("DsInscripciones", InscripcionBindingSource);
            this.RvInscripciones.LocalReport.DataSources.Clear();
            RvInscripciones.LocalReport.DataSources.Add(reportDataSource);

            RvInscripciones.LocalReport.Refresh();
            this.RvInscripciones.RefreshReport();
        }
    }
}
