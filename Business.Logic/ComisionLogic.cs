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




    }
}
