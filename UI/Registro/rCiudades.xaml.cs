using System.Windows;
using System;
using WilsonGomez_P1_AP1.BLL;
using WilsonGomez_P1_AP1.Entidades;

namespace WilsonGomez_P1_AP1.UI.Registros
{
    public partial class rCiudades : Window
    {
        Ciudades ciudad;
        public rCiudades()
        {
            InitializeComponent();
            ciudad = new Ciudades();
        }

        private void Limpiar()
        {
            this.ciudad = new Ciudades();
            this.DataContext = ciudad;
        }

        private bool Validar()
        {
            bool valido = true;

            if(NombresTextbox.Text.Length == 0)
            {
                valido = false;
                MessageBox.Show("Error, ciudad no válida. El nombre está vacio.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if(Convert.ToInt32(CiudadIdTextbox.Text) > 0 || Convert.ToInt32(CiudadIdTextbox.Text) < 0 )
            {
                valido = false;
                MessageBox.Show("Error, ciudad no válida. El ID de la ciudad va vacío", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return valido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var ciudad = CiudadesBLL.Buscar(Convert.ToInt32(CiudadIdTextbox.Text));
            if(ciudad != null)
            {
                this.ciudad = ciudad;
            }
            else
            {
                this.ciudad = new Ciudades();
            }
            this.DataContext = this.ciudad;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }  

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if(!Validar())
                return;
                
            var guardo = CiudadesBLL.Guardar(ciudad);

            if(guardo)
            {
                Limpiar();
                MessageBox.Show("Se guardó exitosamente.", "¡Exito!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar la ciudad.", "¡Fallo!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(CiudadesBLL.Eliminar(Convert.ToInt32(CiudadIdTextbox.Text)))
            {
                Limpiar();
                MessageBox.Show("Se eliminó exitosamente.", "¡Exito!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la ciudad. El ID ingrasado no coincide con ninguna ciudad.", "¡Fallo!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}