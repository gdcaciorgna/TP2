using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {

        public PersonaAdapter PersonaData { get; set; }

        private Data.Database.UsuarioAdapter _usuarioData;

        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();

        }

        public List<Persona> GetAll()
        {
            try
            {
                return this.PersonaData.GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public Persona GetOne(int pID)      // punto 8
        {
            try
            {
                return this.PersonaData.GetOne(pID);
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
                this.PersonaData.Delete(pID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Save(Persona per)      // punto 10
        {
            this.PersonaData.Save(per);
        }

        public int GetTipoPersona(Persona per)
        {
            try
            {
                int tipo_persona = this.PersonaData.getTipoPersona(per);
                return tipo_persona;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }


        public List<Persona> GetAllTipo(int tipo_per) 
        {
            return PersonaData.GetAllTipo(tipo_per);
        }

    }
}
