using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Cliente : IDataErrorInfo, INotifyPropertyChanged
    {
        private string cli_Dni;

        public string Cli_Dni
        {
            get { return cli_Dni; }
            set { cli_Dni = value;
            notificador(cli_Dni);
            }
        }
        private string cli_Apellido;

        public string Cli_Apellido
        {
            get { return cli_Apellido; }
            set { cli_Apellido = value;
            notificador(cli_Apellido);
            }
        }
        private string cli_Nombre;

        public string Cli_Nombre
        {
            get { return cli_Nombre; }
            set { cli_Nombre = value;
            notificador(cli_Nombre);
            }
        }
        private string cli_Telefono;

        public string Cli_Telefono
        {
            get { return cli_Telefono; }
            set { cli_Telefono = value;
            notificador(cli_Telefono);
            }
        }

        public string Error
        {
            get
            {
                string msgError = "";
                if (validarClienteDNI() == null)
                    msgError += "";
                else
                    msgError += validarClienteDNI();

                if (validarApellido() == null)
                    msgError += "";
                else
                    msgError += validarApellido();

                if (validarNombre() == null)
                    msgError += "";
                else
                    msgError += validarNombre();

                if (validarTelefono() == null)
                    msgError += "";
                else
                    msgError += validarTelefono();
                return msgError;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string msgError = null;
                switch (columnName)
                {
                    case "Cli_Dni":
                        msgError = validarClienteDNI();
                        break;
                    case "Cli_Apellido":
                        msgError = validarApellido();
                        break;
                    case "Cli_Nombre":
                        msgError = validarNombre();
                        break;
                    case "Cli_Telefono":
                        msgError = validarTelefono();
                        break;
                }
                return msgError;
            }
        }


        private string validarClienteDNI()
        {
            if (String.IsNullOrEmpty(cli_Dni))
            {
                return "El DNI es obligatorio\n";
            }
            return null;
        }

        private string validarApellido()
        {
            if (String.IsNullOrEmpty(Cli_Apellido))
            {
                return "El Apellido es obligatorio\n";
            }
            return null;
        }
        private string validarNombre()
        {
            if (String.IsNullOrEmpty(cli_Nombre))
            {
                return "El Nombre es obligatorio\n";
            }
            return null;
        }
        private string validarTelefono()
        {
            if (String.IsNullOrEmpty(cli_Telefono))
            {
                return "El Telefono es obligatorio\n";
            }
            return null;
        }

        public override string ToString()
        {
            string msg = "DNI: " + Cli_Dni + "\nApellido: " + Cli_Apellido + "\nNombre: " + Cli_Nombre + "\nTelefono: " + cli_Telefono;
            return msg;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void notificador(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
