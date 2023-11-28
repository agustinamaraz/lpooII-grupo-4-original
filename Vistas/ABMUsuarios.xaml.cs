using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ABMUsuarios.xaml
    /// </summary>
    public partial class ABMUsuarios : Window
    {
        public ABMUsuarios()
        {
            InitializeComponent();
        }

        CollectionView Vista;
        ObservableCollection<Usuario> listaUsuario;

        int savmod = 0, indice = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //obtener la coleccion y asignaamos los recursos que tenemos dentro de listuser
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_USER"];
            //hacer que los datos se muestren como observableCollection
            listaUsuario = odp.Data as ObservableCollection<Usuario>;

            //vista es colection view para convertir datos en una vista
            Vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_content.DataContext);

            //no darle mucha importancia es mas para los textbox
            deshabilitarCampos();
            btnCancelar.IsEnabled = false;
            btnGuardar.IsEnabled = false;
        }

        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            btnEliminarUsuario.IsEnabled = false;
            btnNuevoUsuario.IsEnabled = false;
            btnActualizar.IsEnabled = false;
            limpiarCampos();
            habilitarCampos();
            savmod = 0;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            if (savmod == 0)
            {
                Usuario usuario = new Usuario();
                usuario.Usr_UserName = txtUsername.Text;
                usuario.Usr_Apellido = txtApellido.Text;
                usuario.Usr_Nombre = txtNombre.Text;
                usuario.Usr_Password = txtPassword.Text;
                usuario.Usr_Email = txtEmail.Text;
                usuario.Usr_Rol = cboRol.SelectedValue.ToString();
                MessageBoxResult msg = MessageBox.Show(usuario.ToString(), "Confirmacion", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                if (msg == MessageBoxResult.OK)
                {
                    TrabajarUsuario.nuevoUsuario(usuario);
                    listaUsuario.Add(usuario);

                    MessageBox.Show("Usuario agregado correctamente");
                    Vista.MoveCurrentToLast();
                }
            }
            else
            {
                if (savmod == 1)
                {
                    Usuario usr = new Usuario();
                    usr.Usr_Id = this.indice;
                    usr.Usr_UserName = txtUsername.Text;
                    usr.Usr_Apellido = txtApellido.Text;
                    usr.Usr_Nombre = txtNombre.Text;
                    usr.Usr_Password = txtPassword.Text;
                    usr.Usr_Email = txtEmail.Text;
                    usr.Usr_Rol = cboRol.SelectedValue.ToString();
                    MessageBox.Show(usr.ToString());
                    //sentencias sql para modificar
                    MessageBoxResult msg = MessageBox.Show(usr.ToString(), "Confirmacion", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                    if (msg == MessageBoxResult.OK)
                    {
                        TrabajarUsuario.modificarUsuario(usr);

                        MessageBox.Show("Usuario actualizado Correctamente");
                        Vista.MoveCurrentToLast();
                        Vista.MoveCurrentToPosition(0);
                    }
                }


            }
            limpiarCampos();
            deshabilitarCampos();
            btnNuevoUsuario.IsEnabled = true;
            btnGuardar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            btnEliminarUsuario.IsEnabled = true;
            btnActualizar.IsEnabled = true;

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            int indice = Vista.CurrentPosition;

            txtApellido.Text = listaUsuario[indice].Usr_Apellido;
            txtNombre.Text = listaUsuario[indice].Usr_Nombre;
            txtUsername.Text = listaUsuario[indice].Usr_UserName;
            txtPassword.Text = listaUsuario[indice].Usr_Password;
            txtEmail.Text = listaUsuario[indice].Usr_Email;
            cboRol.SelectedValue = listaUsuario[indice].Usr_Rol;
            habilitarCampos();
            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            btnEliminarUsuario.IsEnabled = false;
            btnNuevoUsuario.IsEnabled = false;
            btnActualizar.IsEnabled = false;
            savmod = 1;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            btnGuardar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            btnEliminarUsuario.IsEnabled = true;
            btnNuevoUsuario.IsEnabled = true;
            btnActualizar.IsEnabled = true;
            limpiarCampos();
        }

        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            int identificador = listaUsuario[Vista.CurrentPosition].Usr_Id;
            MessageBoxResult msg = MessageBox.Show("Desea realmente eliminar el Usuario" + Vista.CurrentItem.ToString(), "Confirmacion", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if (msg == MessageBoxResult.OK)
            {
                Usuario usuario = new Usuario();
                TrabajarUsuario.eliminarUsuario(identificador);
                listaUsuario.RemoveAt(Vista.CurrentPosition);
                MessageBox.Show("Usuario eliminado correctamente.");
                //actualizarVista();
            }
            else
            {
                MessageBox.Show("Operacion Cancelada");
            }
        }

        private void actualizarVista()
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources[TrabajarUsuario.traerUsuarios()];
            listaUsuario = odp.Data as ObservableCollection<Usuario>;
            Vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_content.DataContext);
            Vista.Filter = null;
        }

        private void btnPrimero_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToFirst();
        }

        private void btnUltimo_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToLast();
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToPrevious();
            if (Vista.IsCurrentBeforeFirst)
            {
                Vista.MoveCurrentToLast();
            }
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToNext();
            if (Vista.IsCurrentAfterLast)
            {
                Vista.MoveCurrentToFirst();
            }
        }

        private void deshabilitarCampos()
        {
            txtApellido.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtPassword.IsEnabled = false;
            txtUsername.IsEnabled = false;
            cboRol.IsEnabled = false;
        }
        private void habilitarCampos()
        {
            txtApellido.IsEnabled = true;
            txtNombre.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtPassword.IsEnabled = true;
            txtUsername.IsEnabled = true;
            cboRol.IsEnabled = true;
        }
        private void limpiarCampos()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
        }

        private void btnGuardarAct_Click(object sender, RoutedEventArgs e)
        {
            Usuario usr = new Usuario();
            usr.Usr_Id = int.Parse(listaUsuario[Vista.CurrentPosition].Usr_Id.ToString());
            usr.Usr_UserName = txtUsername.Text;
            usr.Usr_Apellido = txtApellido.Text;
            usr.Usr_Nombre = txtNombre.Text;
            usr.Usr_Password = txtPassword.Text;
            usr.Usr_Email = txtEmail.Text;
            usr.Usr_Rol = cboRol.SelectedValue.ToString();
            MessageBox.Show(usr.ToString());
            //sentencias sql para modificar
            MessageBoxResult msg = MessageBox.Show(usr.ToString(), "Confirmacion", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if (msg == MessageBoxResult.OK)
            {
                TrabajarUsuario.modificarUsuario(usr);

                MessageBox.Show("Usuario actualizado Correctamente");
                Vista.MoveCurrentToLast();
                Vista.MoveCurrentToPosition(indice);
            }
        }
    }
}