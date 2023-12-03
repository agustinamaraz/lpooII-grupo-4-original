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
using System.Windows.Threading;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for AcercaDe.xaml
    /// </summary>
    public partial class AcercaDe : Window
    {
        bool fileIsPlaying;

        public AcercaDe()
        {
            InitializeComponent();

            string carpetaBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaDirecta = Path.Combine(carpetaBase, "..", "..", "media", "video.wmv");
            mediaElement.Source = new Uri(rutaDirecta);

            mediaElement.MediaEnded += (sender, e) => mediaElement.Position = TimeSpan.Zero;


            abrir();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            meMovie.LoadedBehavior = MediaState.Manual;
            meMovie.Source = new Uri("/Vistas/media/video.wmv", UriKind.Relative);//./Media/Wildlife.wmv


        }

        DispatcherTimer timer;
        public delegate void timerTick();
        timerTick tick;

        private void abrir()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Dispatcher.Invoke(tick);
        }

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
        }

        private void meMovie_MediaEnded(object sender, RoutedEventArgs e)
        {
            meMovie.Stop();
        }

        void changePosition(TimeSpan ts)
        {
            meMovie.Position = ts;
        }

    }
}
