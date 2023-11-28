using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Zona
    {
        private int zonaCodigo;
        private string descripcion;
        private string piso;

        public int ZonaCodigo
        {
            get { return zonaCodigo; }
            set { zonaCodigo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Piso
        {
            get { return piso; }
            set { piso = value; }
        }
    }
}
