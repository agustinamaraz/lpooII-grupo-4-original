using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Usuario : INotifyPropertyChanged
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
