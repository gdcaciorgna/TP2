using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;        // punto 3
using Data.Database;            // punto 3


namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        public Data.Database.UsuarioAdapter UsuarioData     // propiedad, punto 4
        {
            get
            {
                return _usuarioData;
            }

            set
            {
                _usuarioData = value;
            }
        }

        private Data.Database.UsuarioAdapter _usuarioData;

        public UsuarioLogic()       // constructor
        {
            UsuarioData = new UsuarioAdapter();

        }

        public List<Usuario> GetAll()      // puntos 6 y 7
        {
            try
            {
                return this.UsuarioData.GetAll();
            }
            catch(Exception Ex)
            {
               Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de usuarios", Ex);
               throw ExcepcionManejada;
            }
        }

        public Usuario GetOne(int pID)      // punto 8
        {
            try
            {
                return this.UsuarioData.GetOne(pID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(int pID)      // punto 9
        {
            try
            {
                this.UsuarioData.Delete(pID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Usuario pUsuario)      // punto 10
        {
            this.UsuarioData.Save(pUsuario);
        }
        public Usuario GetUsuarioxUsrNombre(string nomUsuario)
        {
            return UsuarioData.GetUsuarioxUsrNombre(nomUsuario);
        }
    }
}
