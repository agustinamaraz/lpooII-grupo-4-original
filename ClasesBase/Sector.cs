using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Sector
    {
        //Descripcion
        private string sec_Descripcion;

        public string Sec_Descripcion
        {
            get { return sec_Descripcion; }
            set { sec_Descripcion = value; }
        }

        //Habilitado
        private bool sec_Habilitado;

        public bool Sec_Habilitado
        {
            get { return sec_Habilitado; }
            set { sec_Habilitado = value; }
        }
        //Identificador
        private string sec_Id;

        public string Sec_Id
        {
            get { return sec_Id; }
            set { sec_Id = value; }
        }

        //SectorCodigo
        private int sec_Codigo;

        public int Sec_Codigo
        {
            get { return sec_Codigo; }
            set { sec_Codigo = value; }
        }

        //zonaCodigo
        private int zona_Codigo;
        public int Zona_Codigo
        {
            get { return zona_Codigo; }
            set { zona_Codigo = value; }
        }

        public Sector() { }

        public Sector(int sectorCodigo, string descripcion, string identificador, bool habilitado, int zonaCodigo)
        {
            Sec_Codigo = sectorCodigo;
            Sec_Descripcion = descripcion;
            Sec_Id = identificador;
            Sec_Habilitado = habilitado;
            zona_Codigo = zonaCodigo;
        }

        public override string ToString()
        {
            return "SectorCodigo: " + Sec_Codigo + ",\nDescripcion: " + Sec_Descripcion + ",\nIdentificador: " + Sec_Id + ",\nHabilitado: " + Sec_Habilitado + ",\nZonaCodigo: " + Zona_Codigo;
        }
    }
}