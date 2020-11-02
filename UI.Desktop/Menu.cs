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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias materias = new Materias();
            materias.ShowDialog();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos cursos = new Cursos();
            cursos.ShowDialog();
        }

        private void btnPersonas2_Click(object sender, EventArgs e)
        {
            Personas personas = new Personas();
            personas.ShowDialog();
        }
    }
}
