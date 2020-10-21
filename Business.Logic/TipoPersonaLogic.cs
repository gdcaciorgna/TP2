using Business.Entities;
using System;
using System.Collections.Generic;

namespace Business.Logic
{
    public class TipoPersonaLogic
    {
        


        public Persona.TiposPersona getTipoPersonaString(String tipoPersonaString) 
        {
            Persona.TiposPersona tipo_per = new Persona.TiposPersona();
            if (tipoPersonaString.Equals("Administrador"))
            {
                tipo_per = Persona.TiposPersona.Administrador;
            }

            else if (tipoPersonaString.Equals("Docente"))
            {
                tipo_per = Persona.TiposPersona.Docente;
            }

            else if (tipoPersonaString.Equals("Alumno")) 
            {
                tipo_per = Persona.TiposPersona.Alumno;
            }

            return tipo_per;

        }

        
    

    }
}
