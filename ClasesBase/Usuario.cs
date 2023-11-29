using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Usuario : INotifyPropertyChanged, IDataErrorInfo
    {
        private string usr_Password;

        public string Usr_Password
        {
            get { return usr_Password; }
            set { usr_Password = value;
            notificador(usr_Password);
            }
        }
        private string usr_Apellido;

        public string Usr_Apellido
        {
            get { return usr_Apellido; }
            set { usr_Apellido = value;
            notificador(usr_Apellido);
            }
        }
        private string usr_Nombre;

        public string Usr_Nombre
        {
            get { return usr_Nombre; }
            set { usr_Nombre = value;
            notificador(usr_Nombre);
            }
        }
        private string usr_Rol;

        public string Usr_Rol
        {
            get { return usr_Rol; }
            set { usr_Rol = value;
            notificador(usr_UserName);
            }
        }
        private string usr_UserName;

        public string Usr_UserName
        {
            get { return usr_UserName; }
            set { usr_UserName = value;
            notificador(usr_UserName);
            }
        }

        private int usr_Id;

        public int Usr_Id
        {
            get { return usr_Id; }
            set { usr_Id = value; }
        }

        private string usr_Email;

        public string Usr_Email
        {
            get { return usr_Email; }
            set { usr_Email = value;
            notificador(usr_UserName);
            }
        }

        public Usuario(string username, string password)
        {
            Usr_UserName = username;
            usr_Password = password;
        }

        public Usuario()
        {
            
        }

        public Usuario(int id)
        {
            Usr_Id = id;
        }

        public string Error
        {
            get
            {
                string msgError = "";
                if (validarPassword() == null)
                    msgError += "";
                else
                    msgError += validarPassword();

                if (validarApellido() == null)
                    msgError += "";
                else
                    msgError += validarApellido();

                if (validarNombre() == null)
                    msgError += "";
                else
                    msgError += validarNombre();

                if (validarRol() == null)
                    msgError += "";
                else
                    msgError += validarRol();

                if (validarEmail() == null)
                    msgError += "";
                else
                    msgError += validarEmail();

            if (validarUsername() == null)
                    msgError += "";
                else
                msgError += validarUsername();
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
                    case "Usr_Password":
                        msgError = validarPassword();
                        break;
                    case "Usr_Apellido":
                        msgError = validarApellido();
                        break;
                    case "Usr_Nombre":
                        msgError = validarNombre();
                        break;
                    case "Usr_Rol":
                        msgError = validarRol();
                        break;
                    case "Usr_UserName":
                        msgError = validarUsername();
                        break;
                    case "Usr_Email":
                        msgError = validarEmail();
                        break;
                }
                return msgError;
            }
        }


        private string validarPassword()
        {
            if (String.IsNullOrEmpty(usr_Password))
            {
                return "La contraseña es obligatoria\n";
            }
            return null;
        }

        private string validarApellido()
        {
            if (String.IsNullOrEmpty(usr_Apellido))
            {
                return "El Apellido es obligatorio\n";
            }
            return null;
        }
        private string validarNombre()
        {
            if (String.IsNullOrEmpty(usr_Nombre))
            {
                return "El Nombre es obligatorio\n";
            }
            return null;
        }
        private string validarRol()
        {
            if (String.IsNullOrEmpty(usr_Rol))
            {
                return "El Rol es obligatorio\n";
            }
            return null;
        }
        private string validarUsername()
        {
            if (String.IsNullOrEmpty(usr_UserName))
            {
                return "El nombre de usuario es obligatorio\n";
            }
            return null;
        }
        private string validarEmail()
        {
            if (String.IsNullOrEmpty(usr_Email))
            {
                return "El email es obligatorio\n";
            }
            return null;
        }

        public override string ToString()
        {
            string msg = "username: " + usr_UserName + "\nApellido: " + usr_Apellido + "\nNombre: " + usr_Nombre + "\nRol: " + usr_Rol;
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
