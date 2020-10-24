﻿using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class PersonasLogic : BusinessLogic
    {
        private Data.Database.PersonasAdapter _PersonaData;
        public Data.Database.PersonasAdapter PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }
        public PersonasLogic()
        {
            PersonaData = new Data.Database.PersonasAdapter();
        }

        public List<Personas> GetAll()
        {
            return PersonaData.GetAll();
        }

        //public int GetOneByDesc(string descripcion)
        //{
        //    return MateriaData.GetOneByDesc(descripcion);
        //}

        public Business.Entities.Personas GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            PersonaData.Delete(ID);
        }

        public void Save(Business.Entities.Personas persona)
        {
            PersonaData.Save(persona);
        }
    }
}
