using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class EspecialidadesLogic
    {
        public EspecialidadesAdapter EspecialidadData { get; set; }

        public List<Especialidad> GetAll()     
        {
            try
            {
                return this.EspecialidadData.GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public Especialidad GetOne(int id)      // punto 8
        {
            try
            {
                return this.EspecialidadData.GetOne(id);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Save(Especialidad esp)      // punto 10
        {
            this.EspecialidadData.Save(esp);
        }

        public EspecialidadesLogic()       // constructor
        {
            EspecialidadData = new EspecialidadesAdapter();

        }

        public void Delete(int pID)      // punto 9
        {
            try
            {
                this.EspecialidadData.Delete(pID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

    }
}
