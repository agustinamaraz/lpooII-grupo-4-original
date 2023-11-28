using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class TipoVehiculo
    {
        private int tipoV_Codigo;

        public int TipoV_Codigo
        {
            get { return tipoV_Codigo; }
            set { tipoV_Codigo = value; }
        }
        private string tipoV_Descripcion;

        public string TipoV_Descripcion
        {
            get { return tipoV_Descripcion; }
            set { tipoV_Descripcion = value; }
        }
        private decimal tipoV_Tarifa;

        public decimal TipoV_Tarifa
        {
            get { return tipoV_Tarifa; }
            set { tipoV_Tarifa = value; }
        }
    }
}