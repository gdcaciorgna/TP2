using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;        
using Data.Database;            


namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        public Data.Database.UsuarioAdapter UsuarioData  
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

        public UsuarioLogic()    
        {
            UsuarioData = new UsuarioAdapter();

        }

        public List<Usuario> GetAll()   
        {
            try
            {
                return this.UsuarioData.GetAll();
            }
            catch(Exception Ex)
            {
               throw Ex;
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
                throw Ex;
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
                throw Ex;
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

        public int GetTipoPersona(Usuario usu) 
        {
            try
            {
                return UsuarioData.getTipoPersona(usu);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
    }
}
