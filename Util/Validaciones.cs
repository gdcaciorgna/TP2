using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Validaciones
    {
        public static bool ControlaClave(String clave1, String clave2)
        {
            if (clave1 == clave2)
            {
                return true;
            }
            else return false;
        }

        public static bool ControlaCampos(string txBox)
        {
            if (String.IsNullOrEmpty(txBox))
                return false;
            else return true;
        }

    }
}
