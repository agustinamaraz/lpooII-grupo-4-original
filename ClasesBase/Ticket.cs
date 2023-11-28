using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Ticket
    {
        private int tick_Numero;

        public int Tick_Numero
        {
            get { return tick_Numero; }
            set { tick_Numero = value; }
        }
        private DateTime tick_FechaHoraEntra;

        public DateTime Tick_FechaHoraEntra
        {
            get { return tick_FechaHoraEntra; }
            set { tick_FechaHoraEntra = value; }
        }
        private DateTime tick_FechaHoraSale;

        public DateTime Tick_FechaHoraSale
        {
            get { return tick_FechaHoraSale; }
            set { tick_FechaHoraSale = value; }
        }
        private int cli_Dni;

        public int Cli_Dni
        {
            get { return cli_Dni; }
            set { cli_Dni = value; }
        }
        private int tipoV_Codigo;

        public int TipoV_Codigo
        {
            get { return tipoV_Codigo; }
            set { tipoV_Codigo = value; }
        }
        private string tick_Patente;

        public string Tick_Patente
        {
            get { return tick_Patente; }
            set { tick_Patente = value; }
        }
        private int sec_Codigo;

        public int Sec_Codigo
        {
            get { return sec_Codigo; }
            set { sec_Codigo = value; }
        }
        private double tick_Duracion;

        public double Tick_Duracion
        {
            get { return tick_Duracion; }
            set { tick_Duracion = value; }
        }
        private decimal tick_Tarifa;

        public decimal Tick_Tarifa
        {
            get { return tick_Tarifa; }
            set { tick_Tarifa = value; }
        }
        private decimal tick_Total;

        public decimal Tick_Total
        {
            get { return tick_Total; }
            set { tick_Total = value; }
        }
    }
}
