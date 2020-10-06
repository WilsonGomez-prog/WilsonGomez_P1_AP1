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

            if(NombresTextbox.Text.Length == 0 || string.IsNullOrEmpty(NombresTextbox.Text) || string.IsNullOrWhiteSpace(NombresTextbox.Text))
            {
                valido = false;
                MessageBox.Show("Error, ciudad no válida. \nEl nombre está vacio.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if(CiudadesBLL.Existe(NombresTextbox.Text))
            {
                valido = false;
                MessageBox.Show("Error, ciudad no válida. \nLa ciudad ya existe en la base de datos.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (valido)
            {
                this.ciudad.Nombres = NombresTextbox.Text;
            }
            return valido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            if(!CiudadesBLL.Existe(Convert.ToInt32(CiudadIdTextbox.Text)))
            {
                MessageBox.Show("Error, ciudad no encontrada. \nLo sentimos, la ciudad no existe en la base de datos.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
            }
            else
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
                MessageBox.Show("No se pudo eliminar la ciudad. \nEl ID ingrasado no coincide con ninguna ciudad.", "¡Fallo!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}