using System.Collections.Generic;
using System;
using WilsonGomez_P1_AP1.Entidades;
using WilsonGomez_P1_AP1.BLL;
using System.Windows;

namespace WilsonGomez_P1_AP1.UI.Consultas
{

    public partial class cCiudades : Window
    {
        public cCiudades()
        {
            InitializeComponent();
        }
        
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Ciudades>();

            if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        lista = CiudadesBLL.GetList(e => e.CiudadID == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                    case 1:
                        lista = CiudadesBLL.GetList(e => e.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    default:
                        MessageBox.Show("Error, opcion no valida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
            }
            else
            {
                lista = CiudadesBLL.GetList(e => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = lista;
        }
    }
}