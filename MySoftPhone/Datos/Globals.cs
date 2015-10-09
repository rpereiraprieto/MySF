using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Datos.Control
{
    public static class Globals
    {

        private static Config cnf;


        public static Config Cnf
        {
            get { return cnf; }
            set { cnf = value; }
        }
       

    }
}
