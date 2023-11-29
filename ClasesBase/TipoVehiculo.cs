using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class TipoVehiculo
    {
        //codigo
        private int tipoV_Codigo;

        public int TipoV_Codigo
        {
            get { return tipoV_Codigo; }
            set { tipoV_Codigo = value; }
        }

        //descripcion
        private string tipoV_Descripcion;

        public string TipoV_Descripcion
        {
            get { return tipoV_Descripcion; }
            set { tipoV_Descripcion = value; }
        }

        //tarifa
        private decimal tipoV_Tarifa;

        public decimal TipoV_Tarifa
        {
            get { return tipoV_Tarifa; }
            set { tipoV_Tarifa = value; }
        }

        //imagen
        private string tipoV_Imagen;

        public string TipoV_Imagen
        {
            get { return tipoV_Imagen; }
            set { tipoV_Imagen = value; }
        }



    }
}