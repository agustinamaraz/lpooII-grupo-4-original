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

using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for VehiculosEnPlaya.xaml
    /// </summary>
    public partial class VehiculosEnPlaya : Window
    {
        public VehiculosEnPlaya()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnE7.Background = Brushes.Gray ;
        }

        private void cambiarEstado(int num)
        {
            switch (num)
            {
                case 1:
                    if (MessageBox.Show("Desea cambiar el estado del sector E1?", "atencion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (btnE1.Background == Brushes.Green)
                        {
                            btnE1.Background = Brushes.Red;
                        }
                        else if (btnE1.Background == Brushes.Red)
                        {
                            btnE1.Background = Brushes.Green;
                        }
                        else
                        {
                            MessageBox.Show("Sector Deshabilitado");
                        }
                    }
                    break;
                case 2:
                    if (MessageBox.Show("Desea cambiar el estado del sector E2?", "atencion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (btnE2.Background == Brushes.Green)
                        {
                            btnE2.Background = Brushes.Red;
                        }
                        else if (btnE2.Background == Brushes.Red)
                        {
                            btnE2.Background = Brushes.Green;
                        }
                        else
                        {
                            MessageBox.Show("Sector Deshabilitado");
                        }
                    }
                    break;
                case 3:
                    if (MessageBox.Show("Desea cambiar el estado del sector E3?", "atencion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (btnE3.Background == Brushes.Green)
                        {
                            btnE3.Background = Brushes.Red;
                        }
                        else if (btnE3.Background == Brushes.Red)
                        {
                            btnE3.Background = Brushes.Green;
                        }
                        else
                        {
                            MessageBox.Show("Sector Deshabilitado");
                        }
                    }
                    break;
                case 4:
                    if (MessageBox.Show("Desea cambiar el estado del sector E4?", "atencion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (btnE4.Background == Brushes.Green)
                        {
                            btnE4.Background = Brushes.Red;
                        }
                        else if (btnE4.Background == Brushes.Red)
                        {
                            btnE4.Background = Brushes.Green;
                        }
                        else
                        {
                            MessageBox.Show("Sector Deshabilitado");
                        }
                    }
                    break;
                case 5:
                    if (MessageBox.Show("Desea cambiar el estado del sector E5?", "atencion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (btnE5.Background == Brushes.Green)
                        {
                            btnE5.Background = Brushes.Red;
                        }
                        else if (btnE5.Background == Brushes.Red)
                        {
                            btnE5.Background = Brushes.Green;
                        }
                        else
                        {
                            MessageBox.Show("Sector Deshabilitado");
                        }
                    }
                    break;
                case 6:
                    if (MessageBox.Show("Desea cambiar el estado del sector E6?", "atencion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (btnE6.Background == Brushes.Green)
                        {
                            btnE6.Background = Brushes.Red;
                        }
                        else if (btnE6.Background == Brushes.Red)
                        {
                            btnE6.Background = Brushes.Green;
                        }
                        else
                        {
                            MessageBox.Show("Sector Deshabilitado");
                        }
                    }
                    break;
                case 7:
                    if (MessageBox.Show("Desea cambiar el estado del sector E7?", "atencion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (btnE7.Background == Brushes.Green)
                        {
                            btnE7.Background = Brushes.Red;
                        }
                        else if (btnE7.Background == Brushes.Red)
                        {
                            btnE7.Background = Brushes.Green;
                        }
                        else
                        {
                            MessageBox.Show("Sector Deshabilitado");
                        }
                    }
                    break;
                case 8:
                    if (MessageBox.Show("Desea cambiar el estado del sector E8?", "atencion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (btnE8.Background == Brushes.Green)
                        {
                            btnE8.Background = Brushes.Red;
                        }
                        else if (btnE8.Background == Brushes.Red)
                        {
                            btnE8.Background = Brushes.Green;
                        }
                        else
                        {
                            MessageBox.Show("Sector Deshabilitado");
                        }
                    }
                    break;
                case 9:
                    if (MessageBox.Show("Desea cambiar el estado del sector E9?", "atencion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (btnE9.Background == Brushes.Green)
                        {
                            btnE9.Background = Brushes.Red;
                        }
                        else if (btnE9.Background == Brushes.Red)
                        {
                            btnE9.Background = Brushes.Green;
                        }
                        else
                        {
                            MessageBox.Show("Sector Deshabilitado");
                        }
                    }
                    break;
                case 10:
                    if (MessageBox.Show("Desea cambiar el estado del sector E10?", "atencion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (btnE10.Background == Brushes.Green)
                        {
                            btnE10.Background = Brushes.Red;
                        }
                        else if (btnE10.Background == Brushes.Red)
                        {
                            btnE10.Background = Brushes.Green;
                        }
                        else
                        {
                            MessageBox.Show("Sector Deshabilitado");
                        }
                    }
                    break;
                default:
                    num = 0;
                    break;
            }
        }

        private void btnE1_Click(object sender, RoutedEventArgs e)
        {
            cambiarEstado(1);
        }

        private void btnE2_Click(object sender, RoutedEventArgs e)
        {
            cambiarEstado(2);
        }

        private void btnE3_Click(object sender, RoutedEventArgs e)
        {
            cambiarEstado(3);
        }

        private void btnE4_Click(object sender, RoutedEventArgs e)
        {
            cambiarEstado(4);
        }

        private void btnE5_Click(object sender, RoutedEventArgs e)
        {
            cambiarEstado(5);
        }

        private void btnE6_Click(object sender, RoutedEventArgs e)
        {
            cambiarEstado(6);
        }

        private void btnE8_Click(object sender, RoutedEventArgs e)
        {
            cambiarEstado(8);
        }

        private void btnE7_Click(object sender, RoutedEventArgs e)
        {
            cambiarEstado(7);
        }

        private void btnE9_Click(object sender, RoutedEventArgs e)
        {
            cambiarEstado(9);
        }

        private void btnE10_Click(object sender, RoutedEventArgs e)
        {
            cambiarEstado(10);
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
    }
}
