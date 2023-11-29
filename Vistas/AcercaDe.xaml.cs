/*using System;
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
using System.Windows.Threading;*/

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
using System.IO;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for AcercaDe.xaml
    /// </summary>
    public partial class AcercaDe : Window
    {
        /*bool fileIsPlaying;

        public AcercaDe()
        {
            InitializeComponent();
            abrir();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            meMovie.LoadedBehavior = MediaState.Manual;
            meMovie.Source = new Uri("D:/Agustina/UNJU/APU/LPOOII/TPS/tp281123-16000/lpooII-grupo-4-original/lpooII-grupo-4-original/Vistas/media/video.wmv", UriKind.Relative);//./Media/Wildlife.wmv


        }

        DispatcherTimer timer;
        public delegate void timerTick();
        timerTick tick;

        private void abrir()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            tick = new timerTick(changeStatus);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Dispatcher.Invoke(tick);
        }

        //visualize progressBar 
        void changeStatus()
        {
            if (fileIsPlaying)
            {
                string sec, min, hours;

                #region personalizar tiempo
                if (meMovie.Position.Seconds < 10)
                    sec = "0" + meMovie.Position.Seconds.ToString();
                else
                    sec = meMovie.Position.Seconds.ToString();


                if (meMovie.Position.Minutes < 10)
                    min = "0" + meMovie.Position.Minutes.ToString();
                else
                    min = meMovie.Position.Minutes.ToString();

                if (meMovie.Position.Hours < 10)
                    hours = "0" + meMovie.Position.Hours.ToString();
                else
                    hours = meMovie.Position.Hours.ToString();

                #endregion personalizar tiempo

                slPosicion.Value = meMovie.Position.TotalMilliseconds;
                //progressBar.Value = meMovie.Position.TotalMilliseconds;

                if (meMovie.Position.Hours == 0)
                {
                    lblTiempo.Content = min + ":" + sec;
                }
                else
                {
                    lblTiempo.Content = hours + ":" + min + ":" + sec;
                }
            }
        }

        novaprivate void ticktimer(Object sender, EventArgs e)
        {
            if (meMovie.Source != null)
            {
                lblTiempo.Content = String.Format("{0}", meMovie.Position.ToString(@"ss"));

            }
        nova}

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            meMovie.Play();
            fileIsPlaying = true;
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            meMovie.Pause();
            fileIsPlaying = false;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            meMovie.Stop();
            fileIsPlaying = false;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void meMovie_MediaOpened(object sender, RoutedEventArgs e)
        {
            timer.Start();
            fileIsPlaying = true;
            //openMedia();
            slPosicion.Maximum = meMovie.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        private void meMovie_MediaEnded(object sender, RoutedEventArgs e)
        {
            meMovie.Stop();
        }

        private void slPosicion_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, (int)slPosicion.Value);
            changePosition(ts);
        }

        private void slPosicion_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //isDragging = true;
        }

        private void slPosicion_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //if (isDragging)
            //{
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, (int)slPosicion.Value);
            changePosition(ts);
            //}
            //isDragging = false;
        }

        void changePosition(TimeSpan ts)
        {
            meMovie.Position = ts;
        }*/


        public AcercaDe()
        {
            InitializeComponent();
            string carpetaBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaDirecta = Path.Combine(carpetaBase, "..", "..", "media", "video.wmv");
            mediaElement.Source = new Uri(rutaDirecta);

            mediaElement.MediaEnded += (sender, e) => mediaElement.Position = TimeSpan.Zero;

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
