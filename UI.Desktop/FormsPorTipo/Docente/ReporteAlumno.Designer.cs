namespace UI.Desktop.FormsPorTipo.Docente
{
    partial class ReporteAlumno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RvInscripciones = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InscripcionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academiaDataSet = new UI.Desktop.academiaDataSet();
            this.alumnos_inscripcionesTableAdapter = new UI.Desktop.academiaDataSetTableAdapters.alumnos_inscripcionesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.InscripcionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academiaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // RvInscripciones
            // 
            this.RvInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RvInscripciones.LocalReport.ReportEmbeddedResource = "UI.Desktop.FormsPorTipo.Docente.ReporteAlumnos.rdlc";
            this.RvInscripciones.Location = new System.Drawing.Point(0, 0);
            this.RvInscripciones.Name = "RvInscripciones";
            this.RvInscripciones.ServerReport.BearerToken = null;
            this.RvInscripciones.Size = new System.Drawing.Size(800, 450);
            this.RvInscripciones.TabIndex = 0;
            // 
            // InscripcionBindingSource
            // 
            this.InscripcionBindingSource.DataMember = "alumnos_inscripciones";
            this.InscripcionBindingSource.DataSource = this.academiaDataSet;
            // 
            // academiaDataSet
            // 
            this.academiaDataSet.DataSetName = "academiaDataSet";
            this.academiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // alumnos_inscripcionesTableAdapter
            // 
            this.alumnos_inscripcionesTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RvInscripciones);
            this.Name = "ReporteAlumno";
            this.Text = "ReporteAlumno";
            this.Load += new System.EventHandler(this.ReporteAlumno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InscripcionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academiaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer RvInscripciones;
        private System.Windows.Forms.BindingSource InscripcionBindingSource;
        private academiaDataSet academiaDataSet;
        private academiaDataSetTableAdapters.alumnos_inscripcionesTableAdapter alumnos_inscripcionesTableAdapter;
    }
}