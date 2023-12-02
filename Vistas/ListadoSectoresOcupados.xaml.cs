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
using System.IO;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ListadoSectoresOcupados.xaml
    /// </summary>
    /// 

    public partial class ListadoSectoresOcupados : Window
    {
        private List<DataRow> _data;

        public ListadoSectoresOcupados()
        {
            InitializeComponent();
            CargarSectoresOcupados();
        }

        private void CargarSectoresOcupados()
        {
            try
            {
                // Obtener DataTable con los sectores ocupados
                DataTable dtSectoresOcupados = TrabajarSector.TraerSectoresOcupados();

                // Calcular tiempo transcurrido
                foreach (DataRow row in dtSectoresOcupados.Rows)
                {
                    if (row["tick_fechahoraentra"] != DBNull.Value)
                    {
                        DateTime fechaEntrada = Convert.ToDateTime(row["tick_fechahoraentra"]);
                        TimeSpan tiempoTranscurrido = DateTime.Now - fechaEntrada;
                        row["TiempoTranscurrido"] = String.Format("{0}hs {1}m", tiempoTranscurrido.Hours, tiempoTranscurrido.Minutes);
                    }
                }

                // Asignar el DataTable al DataGrid
                dgSectoresOcupados.ItemsSource = dtSectoresOcupados.DefaultView;

                // Guardar los datos para imprimir
                _data = new List<DataRow>();
                foreach (DataRow row in dtSectoresOcupados.Rows)
                {
                    _data.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sectores ocupados: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private FlowDocument CrearFlowDocument(List<DataRow> data)
        {
            FlowDocument flowDocument = new FlowDocument();

            foreach (DataRow row in data)
            {
                Paragraph paragraph = new Paragraph();

                paragraph.Inlines.Add(new Run("Sector: " +
            row["sec_descripcion"] + ", Fecha y Hora de Entrada: " +
            row["tick_fechahoraentra"] + ", Apellido y Nombre del Cliente: " +
            row["cliente"] + ", Tipo de Vehículo: " +
            row["tipovehiculo"] + ", Patente: " +
            row["tick_patente"] + ", Tiempo Transcurrido: " +
            row["TiempoTranscurrido"]));


                flowDocument.Blocks.Add(paragraph);
            }

            return flowDocument;
        }

        private void btnImprimirListado_Click(object sender, RoutedEventArgs e)
        {
            ImprimirListado(_data);
        }

        private void ImprimirListado(List<DataRow> data)
        {
            FlowDocument flowDocument = CrearFlowDocument(data);

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                IDocumentPaginatorSource paginatorSource = flowDocument;
                printDialog.PrintDocument(paginatorSource.DocumentPaginator, "Listado de Sectores Ocupados");
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }

    }
}

