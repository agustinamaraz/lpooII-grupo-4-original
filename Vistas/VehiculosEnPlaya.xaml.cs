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
using System.Data;
using System.Data.SqlClient;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for VehiculosEnPlaya.xaml
    /// </summary>
    public partial class VehiculosEnPlaya : Window
    {
        private SolidColorBrush greenBrush;
        private SolidColorBrush redBrush;
        private SolidColorBrush grayBrush;

        public int zona;
        // Crear una lista de sectores extendidos
        List<SectorX> listaDeSectoresExtendidos = new List<SectorX>();

        public VehiculosEnPlaya(int zonaCodigo)
        {
            InitializeComponent();

            redBrush = new SolidColorBrush(Colors.Red);
            greenBrush = new SolidColorBrush(Colors.Green);
            grayBrush = new SolidColorBrush(Colors.Gray);

            this.zona = zonaCodigo;


            DataTable dtSectores = TrabajarSector.TraerSectoresPorZona(this.zona);

            foreach (DataRow row in dtSectores.Rows)
            {
                int sectorCodigo = Convert.ToInt32(row["sec_codigo"]);

                // Obtener el último ticket para el sector
                DataTable dtUltimoTicket = TrabajarTicket.TraerUltimoTicketPorSector(sectorCodigo);

                // Verificar si hay algún ticket para el sector
                if (dtUltimoTicket.Rows.Count > 0)
                {
                    DataRow ultimoTicketRow = dtUltimoTicket.Rows[0];

                    // Obtener la fecha de salida del último ticket
                    decimal? total = ultimoTicketRow["tick_total"] as decimal?;

                    // Si la fecha de salida es nula, el sector está ocupado
                    if (total == 0)
                    {
                        listaDeSectoresExtendidos.Add(new SectorX(
                            sectorCodigo,
                            row["sec_descripcion"].ToString(),
                            row["sec_id"].ToString(),
                            Convert.ToBoolean(row["sec_habilitado"]),
                            Convert.ToInt32(row["zona_codigo"]),
                            "ocupado",
                            Convert.ToInt32(ultimoTicketRow["tick_codigo"])
                        ));
                    }
                    else
                    {
                        // El sector está libre
                        listaDeSectoresExtendidos.Add(new SectorX(
                            sectorCodigo,
                            row["sec_descripcion"].ToString(),
                            row["sec_id"].ToString(),
                            Convert.ToBoolean(row["sec_habilitado"]),
                            Convert.ToInt32(row["zona_codigo"]),
                            "libre",
                            Convert.ToInt32(ultimoTicketRow["tick_codigo"])
                        ));
                    }
                }
                else
                {
                    // No hay ningún ticket para el sector, el sector está libre
                    listaDeSectoresExtendidos.Add(new SectorX(
                        sectorCodigo,
                        row["sec_descripcion"].ToString(),
                        row["sec_id"].ToString(),
                        Convert.ToBoolean(row["sec_habilitado"]),
                        Convert.ToInt32(row["zona_codigo"]),
                        "libre",
                        null
                    ));
                }
            }


            Console.WriteLine("Lista de sectores extendidos:");
            foreach (var SectorX in listaDeSectoresExtendidos)
            {
                Console.WriteLine(string.Format("{0}, {1}, {2}", SectorX.Sec_Id, SectorX.Estado, SectorX.UltimoTicketReservado));
            }

        }

        public VehiculosEnPlaya()
        {
            // TODO: Complete member initialization
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (SectorX sector in listaDeSectoresExtendidos)
            {
                Button btn = ObtenerBotonPorIdentificador(sector.Sec_Id);

                if (sector.Sec_Habilitado)
                {
                    if (sector.Estado == "libre")
                    {
                        btn.Background = greenBrush; // Verde para sectores habilitados y libres
                    }
                    else if (sector.Estado == "ocupado")
                    {
                        btn.Background = redBrush; // Rojo para sectores habilitados y ocupados
                    }
                }
                else
                {
                    btn.Background = grayBrush; // Gris para sectores deshabilitados
                }
            }
        }


        private Button ObtenerBotonPorIdentificador(string identificador)
        {
            // Implementa la lógica para obtener el botón según el identificador.
            // Puedes utilizar un diccionario, una búsqueda en la interfaz gráfica, o alguna otra estructura de datos.
            // Por ejemplo, puedes tener un diccionario donde las claves sean los identificadores y los valores sean los botones correspondientes.
            // Este método debe devolver el botón asociado al identificador.

            // Ejemplo con un diccionario (asegúrate de inicializarlo previamente):
            Dictionary<string, Button> diccionarioBotones = new Dictionary<string, Button>
                {
                    {"E1", btnE1},
                    {"E2", btnE2},
                    {"E3", btnE3},
                    {"E4", btnE4},
                    {"E5", btnE5},
                    {"E6", btnE6},
                    {"E7", btnE7},
                    {"E8", btnE8},
                    {"E9", btnE9},
                    {"E10", btnE10},

                   
                };

            return diccionarioBotones[identificador];
        }

        private void btnE1_Click(object sender, RoutedEventArgs e)
        {
            if (btnE1.Background == greenBrush)
            {
                string contenidoBtnE1 = btnE1.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE1);
                Console.WriteLine(sectorEncontrado.Sec_Codigo.ToString() + "  " + sectorEncontrado.Estado);
                sectorEncontrado.Estado = "ocupado";
                btnE1.Background = redBrush;
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_Codigo);
                registrarEntrada.Show();
            }
            else if (btnE1.Background == redBrush)
            {
                string contenidoBtnE1 = btnE1.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE1);
                registrarSalida registrarSalida = new registrarSalida();
                registrarSalida.Show();

            }
            else if (btnE1.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE2_Click(object sender, RoutedEventArgs e)
        {
            if (btnE2.Background == greenBrush)
            {
                string contenidoBtnE2 = btnE2.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE2);
                Console.WriteLine(sectorEncontrado.Sec_Codigo.ToString() + "  " + sectorEncontrado.Estado);
                sectorEncontrado.Estado = "ocupado";
                btnE1.Background = redBrush;
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_Codigo);
                registrarEntrada.Show();
            }
            else if (btnE2.Background == redBrush)
            {
                string contenidoBtnE2 = btnE2.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE2);
                registrarSalida registrarSalida = new registrarSalida();
                registrarSalida.Show();
            }
            else if (btnE2.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE3_Click(object sender, RoutedEventArgs e)
        {
            if (btnE3.Background == greenBrush)
            {
                string contenidoBtnE3 = btnE3.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE3);
                Console.WriteLine(sectorEncontrado.Sec_Codigo.ToString() + "  " + sectorEncontrado.Estado);
                sectorEncontrado.Estado = "ocupado";
                btnE1.Background = redBrush;
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_Codigo);
                registrarEntrada.Show();
            }
            else if (btnE3.Background == redBrush)
            {
                string contenidoBtnE3 = btnE3.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE3);
                registrarSalida registrarSalida = new registrarSalida();
                registrarSalida.Show();
            }
            else if (btnE3.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE4_Click(object sender, RoutedEventArgs e)
        {
            if (btnE4.Background == greenBrush)
            {
                string contenidoBtnE4 = btnE4.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE4);
                Console.WriteLine(sectorEncontrado.Sec_Codigo.ToString() + "  " + sectorEncontrado.Estado);
                sectorEncontrado.Estado = "ocupado";
                btnE1.Background = redBrush;
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_Codigo);
                registrarEntrada.Show();
            }
            else if (btnE4.Background == redBrush)
            {
                string contenidoBtnE4 = btnE4.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE4);
                registrarSalida registrarSalida = new registrarSalida();
                registrarSalida.Show();
            }
            else if (btnE4.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE5_Click(object sender, RoutedEventArgs e)
        {
            if (btnE5.Background == greenBrush)
            {
                string contenidoBtnE5 = btnE5.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE5);
                Console.WriteLine(sectorEncontrado.Sec_Codigo.ToString() + "  " + sectorEncontrado.Estado);
                sectorEncontrado.Estado = "ocupado";
                btnE1.Background = redBrush;
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_Codigo);
                registrarEntrada.Show();
            }
            else if (btnE5.Background == redBrush)
            {
                string contenidoBtnE5 = btnE5.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE5);
                registrarSalida registrarSalida = new registrarSalida();
                registrarSalida.Show();
            }
            else if (btnE5.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE6_Click(object sender, RoutedEventArgs e)
        {
            if (btnE6.Background == greenBrush)
            {
                string contenidoBtnE6 = btnE6.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE6);
                Console.WriteLine(sectorEncontrado.Sec_Codigo.ToString() + "  " + sectorEncontrado.Estado);
                sectorEncontrado.Estado = "ocupado";
                btnE1.Background = redBrush;
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_Codigo);
                registrarEntrada.Show();
            }
            else if (btnE6.Background == redBrush)
            {
                string contenidoBtnE6 = btnE6.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE6);
                registrarSalida registrarSalida = new registrarSalida();
                registrarSalida.Show();
            }
            else if (btnE6.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE7_Click(object sender, RoutedEventArgs e)
        {
            if (btnE7.Background == greenBrush)
            {
                string contenidoBtnE7 = btnE7.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE7);
                Console.WriteLine(sectorEncontrado.Sec_Codigo.ToString() + "  " + sectorEncontrado.Estado);
                sectorEncontrado.Estado = "ocupado";
                btnE1.Background = redBrush;
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_Codigo);
                registrarEntrada.Show();
            }
            else if (btnE7.Background == redBrush)
            {
                string contenidoBtnE7 = btnE7.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE7);
                registrarSalida registrarSalida = new registrarSalida();
                registrarSalida.Show();
            }
            else if (btnE7.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE8_Click(object sender, RoutedEventArgs e)
        {
            if (btnE8.Background == greenBrush)
            {
                string contenidoBtnE8 = btnE8.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE8);
                Console.WriteLine(sectorEncontrado.Sec_Codigo.ToString() + "  " + sectorEncontrado.Estado);
                sectorEncontrado.Estado = "ocupado";
                btnE1.Background = redBrush;
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_Codigo);
                registrarEntrada.Show();
            }
            else if (btnE8.Background == redBrush)
            {
                string contenidoBtnE8 = btnE8.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE8);
                registrarSalida registrarSalida = new registrarSalida();
                registrarSalida.Show();
            }
            else if (btnE8.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE9_Click(object sender, RoutedEventArgs e)
        {
            if (btnE9.Background == greenBrush)
            {
                string contenidoBtnE9 = btnE9.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE9);
                Console.WriteLine(sectorEncontrado.Sec_Codigo.ToString() + "  " + sectorEncontrado.Estado);
                sectorEncontrado.Estado = "ocupado";
                btnE1.Background = redBrush;
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_Codigo);
                registrarEntrada.Show();
            }
            else if (btnE9.Background == redBrush)
            {
                string contenidoBtnE9 = btnE9.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE9);
                registrarSalida registrarSalida = new registrarSalida();
                registrarSalida.Show();
            }
            else if (btnE9.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE10_Click(object sender, RoutedEventArgs e)
        {
            if (btnE10.Background == greenBrush)
            {
                string contenidoBtnE10 = btnE10.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE10);
                Console.WriteLine(sectorEncontrado.Sec_Codigo.ToString() + "  " + sectorEncontrado.Estado);
                sectorEncontrado.Estado = "ocupado";
                btnE1.Background = redBrush;
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_Codigo);
                registrarEntrada.Show();
            }
            else if (btnE10.Background == redBrush)
            {
                string contenidoBtnE10 = btnE10.Content.ToString();
                SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == contenidoBtnE10);
                registrarSalida registrarSalida = new registrarSalida();
                registrarSalida.Show();
            }
            else if (btnE10.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnE1_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E1");
        }

        private void btnE2_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E2");
        }

        private void btnE3_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E3");
        }

        private void btnE4_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E4");
        }

        private void btnE5_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E5");
        }

        private void btnE6_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E6");
        }

        private void btnE7_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E7");
        }

        private void btnE8_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E8");
        }

        private void btnE9_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E9");
        }

        private void btnE10_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E10");
        }


        private void MostrarInformacionTiempoLibre(SectorX sector)
        {
            if (sector.UltimoTicketReservado != null)
            {
                DataTable dtTicket = TrabajarTicket.TraerTicketPorNumero(sector.UltimoTicketReservado);

                if (dtTicket.Rows.Count > 0)
                {
                    DateTime horaFinal = Convert.ToDateTime(dtTicket.Rows[0]["tick_fechahorasale"]);
                    TimeSpan tiempoLibre = DateTime.Now - horaFinal;

                    // Muestra el tiempo que lleva libre el sector en formato días:horas:minutos:segundos
                    string tiempoLibreFormato = string.Format("{0} días, {1:D2}:{2:D2}:{3:D2}", tiempoLibre.Days, tiempoLibre.Hours, tiempoLibre.Minutes, tiempoLibre.Seconds);

                    Button boton = ObtenerBotonPorIdentificador(sector.Sec_Id);
                    if (boton != null)
                    {
                        boton.ToolTip = new ToolTip { Content = string.Format("Estado: {0}, Tiempo libre: {1}", sector.Estado, tiempoLibreFormato) };
                    }
                }
            }


            else
            {
                // Si el sector nunca ha sido ocupado, establecer una fecha y hora de inicio de referencia
                TimeSpan tiempoLibre = DateTime.Now - DateTime.Now.AddYears(-1);        // Resta un año a la fecha actual

                // Muestra el tiempo que lleva libre el sector en formato días:horas:minutos:segundos
                string tiempoLibreFormato = string.Format("{0} días, {1:D2}:{2:D2}:{3:D2}", tiempoLibre.Days, tiempoLibre.Hours, tiempoLibre.Minutes, tiempoLibre.Seconds);

                Button boton = ObtenerBotonPorIdentificador(sector.Sec_Id);
                if (boton != null)
                {
                    boton.ToolTip = new ToolTip { Content = string.Format("Estado: {0}, Tiempo libre: {1}", sector.Estado, tiempoLibreFormato) };
                }
            }
        }


        private void MostrarInformacionTiempoOcupado(SectorX sector)
        {
            if (sector.UltimoTicketReservado != null)
            {
                DataTable dtTicket = TrabajarTicket.TraerTicketPorNumero(sector.UltimoTicketReservado);

                if (dtTicket.Rows.Count > 0)
                {
                    DateTime horaInicio = Convert.ToDateTime(dtTicket.Rows[0]["tick_fechahoraentra"]);
                    TimeSpan tiempoOcupado = DateTime.Now - horaInicio;

                    // Obtener información adicional del ticket
                    string tipoVehiculo = dtTicket.Rows[0]["tipov_codigo"].ToString();
                    decimal tarifaPorHora = Convert.ToDecimal(dtTicket.Rows[0]["tick_tarifa"]);
                    string descripcionSector = sector.Sec_Descripcion;

                    // Calcular el monto a pagar
                    decimal montoPagar = CalcularMontoPagar(tiempoOcupado, tarifaPorHora);

                    // Muestra el tiempo que lleva ocupado el sector, tipo de vehículo, monto a pagar y descripción del sector
                    string tiempoOcupadoFormato = string.Format("{0} días, {1:D2}:{2:D2}:{3:D2}", tiempoOcupado.Days, tiempoOcupado.Hours, tiempoOcupado.Minutes, tiempoOcupado.Seconds);

                    Button boton = ObtenerBotonPorIdentificador(sector.Sec_Id);
                    if (boton != null)
                    {
                        boton.ToolTip = new ToolTip { Content = string.Format("Estado: {0}, Tiempo ocupado: {1}\nCodigo de Vehículo: {2}\nMonto a Pagar: {3:C}\nDescripción del Sector: {4}", sector.Estado, tiempoOcupadoFormato, tipoVehiculo, montoPagar, descripcionSector) };
                    }
                }
            }
        }


        private decimal CalcularMontoPagar(TimeSpan tiempoOcupado, decimal tarifaPorHora)
        {
            // Calcular el monto a pagar multiplicando la tarifa por la cantidad de horas ocupadas
            decimal montoTotal = tarifaPorHora * (decimal)tiempoOcupado.TotalHours;

            return montoTotal;
        }


        private void mostrarEstadoSector(string identificadorSector)
        {


            // Filtra la lista por identificador
            SectorX sectorEncontrado = listaDeSectoresExtendidos.FirstOrDefault(s => s.Sec_Id == identificadorSector);


            if (sectorEncontrado != null)
            {
                Button boton = ObtenerBotonPorIdentificador(identificadorSector);
                if (boton != null)
                {
                    if (sectorEncontrado.Sec_Habilitado)
                    {
                        //boton.ToolTip = new ToolTip { Content = "Estado: " + sectorEncontrado.Estado };
                        if (sectorEncontrado.Estado == "libre") MostrarInformacionTiempoLibre(sectorEncontrado);
                        else if (sectorEncontrado.Estado == "ocupado") MostrarInformacionTiempoOcupado(sectorEncontrado);
                    }
                }
            }
            else
            {
                Console.WriteLine("No se encontró ningún sector con el identificador " + identificadorSector);
            }

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            VehiculosEnPlaya sector = new VehiculosEnPlaya(this.zona);
            sector.Show();
            this.Close();

        }


    }
}