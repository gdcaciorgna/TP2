using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class DocenteCurso : BusinessEntity
    {
        private int _IDCurso;
        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        private int _IDDocente;
        public int IDDocente
        {
            get { return _IDDocente; }
            set { _IDDocente = value; }
        }

        private TiposCargo _Cargo;
        public TiposCargo Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        public enum TiposCargo
        {
            Titular,
            Practica,
            Auxiliar
        }

        public DocenteCurso()
        {
            this.Cargo = new TiposCargo();
        }
    }
}
