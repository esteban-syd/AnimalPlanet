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
using System.Windows.Shapes;
using Animal.Negocios;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Animal.Presentacionn
{
    /// <summary>
    /// Lógica de interacción para cliente.xaml
    /// </summary>
    public partial class cliente : MetroWindow
    {
        Manejadora mane = new Manejadora();
        
        public cliente()
        {
            InitializeComponent();

            cmbPago.ItemsSource =Enum.GetValues(typeof(MetodoPago));
        }
        public void Limpiar()
        {
            TxtIdU.Text = "";
            TxtNombreD.Text = "";
            TxtRut.Text = "";
            TxtEdad.Text = "";
            TxtIdU.Focus();
        }               
        private async void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cli = new Cliente
                (
                int.Parse(TxtIdU.Text),
                int.Parse(TxtEdad.Text),
                TxtRut.Text,
                TxtNombreD.Text,
                cmbPago.SelectedValue.ToString());

                if (cli.Create())
                {
                    await this.ShowMessageAsync("Felicidades", "Cliente Agregado");
                   

                    Limpiar();
                }
                

                else
                {
                    await this.ShowMessageAsync("Error", "No es posible agregar usuario");
                }
               

            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "Error", MessageBoxButton.OK,MessageBoxImage.Error);

            }
                                                  
        }
        private async void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cli= new Cliente()
                {
                    Id = int.Parse(TxtIdU.Text),
                    Edad = int.Parse(TxtEdad.Text),
                    Rut = TxtRut.Text,
                    Nombre = TxtNombreD.Text,
                    MetoPago= (MetodoPago)(cmbPago.SelectedValue),            
                };
            if (cli.Update())
            {
                Limpiar();
                    await this.ShowMessageAsync ("Cliente Modificado","Buen Trabajo");
            }
            else
            {
                    await this.ShowMessageAsync("Error", "No se puede agregar Cliente ");
                }
        }
            catch (Exception AA)
            {
                MessageBox.Show(AA.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                TxtIdU.Text = "";
                TxtEdad.Text = "";
                TxtRut.Text = "";
                TxtNombreD.Text="";
                cmbPago.Text = null;
            }

}
        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cli = new Cliente()
                {
                    Rut = TxtRut.Text
                };
                if (cli.Delete())
                {
                    Limpiar();
                    await this.ShowMessageAsync("Cliente Eliminado", "Buen Trabajo");
                }
                else
                {
                    TxtIdU.Text = "";
                    TxtRut.Text = "";
                    TxtNombreD.Text = "";                  
                    TxtEdad.Text = "";

                }
            }
            catch (Exception BB)
            {
                MessageBox.Show(BB.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                TxtIdU.Text = "";
                TxtRut.Text = "";
                TxtNombreD.Text = "";
                 TxtEdad.Text = "";


            }


        }
        private async void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente clien = new Cliente()
                {
                    Rut = TxtRut.Text
                };
                if (clien.Read())
                {
                    TxtIdU.Text = clien.Id.ToString();
                    TxtEdad.Text = clien.Edad.ToString();
                    TxtRut.Text = clien.Rut;
                    TxtNombreD.Text = clien.Nombre;
                    cmbPago.SelectedValue = clien.MetoPago;

                }
                else
                {
                    TxtIdU.Text = "";
                    TxtEdad.Text = "";
                    TxtRut.Text = "";
                    TxtNombreD.Text = "";
                    await this.ShowMessageAsync("Buscar", "Cliente Encontrado"); 

                }
            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                TxtIdU.Text = "";
                TxtEdad.Text = "";
                TxtRut.Text = "";
                TxtNombreD.Text = "";
            }
        }
   
        private void BtnMostrar_Click(object sender, RoutedEventArgs e)
        {
            dgtDueñoMascota.ItemsSource = (from a in mane.ListarClientes()
                                           select new
                                           {
                                               id = a.Id,
                                               edad = a.Edad,
                                               rut = a.Rut,
                                               nom = a.Nombre,
                                               pago = a.MetoPago,
                                           }
                                        ).ToArray();

        }

        private void BtnVolverClli_Click(object sender, RoutedEventArgs e)
        {

            Menu men = new Menu();
            men.Visibility = Visibility.Visible;


            this.Close();
        }
    } 
}
