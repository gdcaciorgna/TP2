using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {

        public ComisionAdapter ComisionData { get; set; }

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public List<Comision> GetAll()
        {
            try
            {
                return this.ComisionData.GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public Comision GetOne(int pID)      // punto 8
        {
            try
            {
                return this.ComisionData.GetOne(pID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public Comision GetOne(Curso cur)
        {
            try
            {
                return this.ComisionData.GetOne(cur);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }


        }

        public void Delete(int pID)      // punto 9
        {
            try
            {
                this.ComisionData.Delete(pID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Save(Comision com)      // punto 10
        {
            this.ComisionData.Save(com);
        }




    }
}
