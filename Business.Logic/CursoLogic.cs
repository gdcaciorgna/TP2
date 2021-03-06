﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {

        public CursoAdapter CursoData { get; set; }

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public List<Curso> GetAll()
        {
            try
            {
                return this.CursoData.GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<int> GetAllAnios()
        {
            try
            {
                return this.CursoData.GetAllAnios();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }



        public Curso GetOne(int cID)    
        {
            try
            {
                return this.CursoData.GetOne(cID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public Curso GetOne(int id_comision, int id_materia, int anio_calendario)      
        {
            try
            {
                return this.CursoData.GetOne(id_comision, id_materia, anio_calendario);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Delete(int cID)      // punto 9
        {
            try
            {
                this.CursoData.Delete(cID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Save(Curso curso)      // punto 10
        {
            this.CursoData.Save(curso);
        }

    }
}
