using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WilsonGomez_P1_AP1.UI.Consultas;
using WilsonGomez_P1_AP1.UI.Registros;

namespace WilsonGomez_P1_AP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void rCiudadesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rCiudades registroCiudad = new rCiudades();
            registroCiudad.Show();
        }

        public void cCiudadesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cCiudades consultaCiudad = new cCiudades();
            consultaCiudad.Show();
        }
    }
}
