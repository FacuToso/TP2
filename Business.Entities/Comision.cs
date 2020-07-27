using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class Comision : BusinessEntity
    {
        #region Propiedades

        private int _AnioEspecialidad;

        public int AnioEspecialidad
        {
            get { return _AnioEspecialidad;  }
            set { _AnioEspecialidad = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _IDPlan;
        public string IDPlan

        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }




        #endregion
    }
}
