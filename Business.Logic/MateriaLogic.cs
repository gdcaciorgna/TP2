using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        public MateriaAdapter MateriaData { get; set; }

        public List<Materia> GetAll()
        {
            try
            {
                return this.MateriaData.GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public Materia GetOne(int id)      // punto 8
        {
            try
            {
                return this.MateriaData.GetOne(id);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Save(Materia mat)      // punto 10
        {
            this.MateriaData.Save(mat);
        }

        public MateriaLogic()       // constructor
        {
            MateriaData = new MateriaAdapter();

        }


    }
}
