using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class ComisionDesktop : ApplicationForm
    {
        #region Constructores
        public ComisionDesktop()
        {
            InitializeComponent();
        }
        public ComisionDesktop(ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
            ComisionLogic comisiones = new ComisionLogic();
            ComisionActual = comisiones.GetOne(ID);
            MapearDeDatos();
        }
        #endregion

        #region Propiedades

        public Comision ComisionActual { get; set; }

        #endregion

        #region Metodos



        #endregion
    }
}
