using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanesLogic : BusinessLogic
    {

        public PlanAdapter PlanData { get; set; }

        public PlanesLogic() 
        {
            PlanData = new PlanAdapter();
        }

        public List<Plan> GetAll()  
        {
            try
            {
                return this.PlanData.GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public Plan GetOne(int pID)      // punto 8
        {
            try
            {
                return this.PlanData.GetOne(pID);
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
                this.PlanData.Delete(pID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Save(Plan plan)      // punto 10
        {
            this.PlanData.Save(plan);
        }

}
}
