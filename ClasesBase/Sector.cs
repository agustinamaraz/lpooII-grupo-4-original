using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Sector
    {
        private string sec_Descripcion;

        public string Sec_Descripcion
        {
            get { return sec_Descripcion; }
            set { sec_Descripcion = value; }
        }
        private bool sec_Habilitado;

        public bool Sec_Habilitado
        {
            get { return sec_Habilitado; }
            set { sec_Habilitado = value; }
        }
        private string sec_Id;

        public string Sec_Id
        {
            get { return sec_Id; }
            set { sec_Id = value; }
        }
        private int sec_Codigo;

        public int Sec_Codigo
        {
            get { return sec_Codigo; }
            set { sec_Codigo = value; }
        }
    }
}
