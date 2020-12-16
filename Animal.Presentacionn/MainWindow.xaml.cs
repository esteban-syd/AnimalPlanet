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
using Animal.Negocios;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using ControlzEx.Theming;



namespace Animal.Presentacionn
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
       
        Manejadora mane = new Manejadora ();
        public MainWindow()
        {
           
   
            InitializeComponent();
           // ThemeManager.Current.ChangeTheme(this, "Dark.Blue");




            cmbAtencion.ItemsSource = Enum.GetValues(typeof(TipoAtencion));
            cmbRaza.ItemsSource = Enum.GetValues(typeof(TipoRaza));
            cmbEster.ItemsSource = Enum.GetValues(typeof(Esterilizados));
            cmbSexo.ItemsSource = Enum.GetValues(typeof(Sexos));
         

        }
        public void Limpiar()
        {
            txtIdM.Text = "";
            txtEdadM.Text = "";
            txtNombreM.Text = "";
            cmbRaza.SelectedValue = null;
            dpFecha.SelectedDate = null;
            cmbEster.SelectedValue = null;
            cmbSexo.SelectedValue = null;
            cmbAtencion.SelectedValue = null;
            txtIdM.Focus();
        }
     
        private  async void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mascota mas = new Mascota(
                int.Parse(txtIdM.Text),
                txtNombreM.Text,
                int.Parse(txtEdadM.Text),
                cmbRaza.SelectedValue.ToString(),
                cmbEster.SelectedValue.ToString(),
                cmbSexo.SelectedValue.ToString(),
                cmbAtencion.SelectedValue.ToString(),
                dpFecha.SelectedDate.Value);

                if (mas.Create())
                {
                    await this.ShowMessageAsync("Buen trabajo", "Mascota Agregada ");

                }


                else
                {
                    await this.ShowMessageAsync("Error", "No se puede agregar mascota");
                }               
            }
            catch ( Exception zz)
            {
                MessageBox.Show(zz.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Limpiar();

            


        }
        private async void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Mascota mas = new Mascota()
                {
                    Id = int.Parse(txtIdM.Text)
                };
                if (mas.Read())
                {
                    txtIdM.Text = mas.Id.ToString();
                    txtNombreM.Text = mas.Nombre;
                    txtEdadM.Text = mas.Edadm.ToString();
                    cmbRaza.SelectedValue = mas.Raza;
                    dpFecha.SelectedDate= mas.FechaNaci;
                    cmbEster.SelectedValue = mas.Esterilizado;
                    cmbSexo.SelectedValue = mas.Sexo;
                    cmbAtencion.SelectedValue = mas.TipoAte;

                }
                else
                {
                    txtIdM.Text = "";
                    txtNombreM.Text = "";
                    txtEdadM.Text = "";

                    await this.ShowMessageAsync("Error", "No se encontro mascota");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtIdM.Text = "";
                txtNombreM.Text = "";
                txtEdadM.Text = "";
            }
        }  
        private async void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mascota masco = new Mascota()
                {
                    Id = int.Parse(txtIdM.Text),
                    Nombre = txtNombreM.Text,
                    Edadm = int.Parse(txtEdadM.Text),
                    Raza = (TipoRaza)(cmbRaza.SelectedValue),
                    FechaNaci = dpFecha.SelectedDate.Value,
                    Esterilizado = (Esterilizados)(cmbEster.SelectedValue),
                    Sexo = (Sexos)(cmbSexo.SelectedValue),
                    TipoAte = (TipoAtencion)(cmbAtencion.SelectedValue)

                };
                if (masco.Update())
                {
                    Limpiar();
                    await this.ShowMessageAsync( "Buen Trabajo","Mascota Actualizada");
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Mascota no actualizada ");
                }
            }
            catch (Exception AA)
            {
                MessageBox.Show(AA.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtIdM.Text = "";
                txtNombreM.Text="";
                txtEdadM.Text="";
            }
        }
        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mascota mas = new Mascota()
                {
                    Nombre =txtNombreM.Text            

                };
                if (mas.Delete())
                {
                    Limpiar();
                    await this.ShowMessageAsync("Buen trabajo", "Mascota eliminada ");

                }
                else
                {
                    txtIdM.Text = "";
                    txtNombreM.Text = "";
                    txtEdadM.Text = "";

                }
            }
            catch (Exception BB)
            {
                MessageBox.Show(BB.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtIdM.Text = "";
                txtNombreM.Text = "";
                txtEdadM.Text = "";


            }
        }
        private void BtnMostrar__Click(object sender, RoutedEventArgs e)
        {
          
                dgtMostrar.ItemsSource = (from a in mane.ListarMascotas()
                                          select new
                                          {
                                              id = a.Id,
                                              nom = a.Nombre,
                                              edad = a.Edadm,
                                              raza = a.Raza,
                                              fechaNacimiento = a.FechaNaci,
                                              sexo = a.Sexo,
                                              esrerilizado = a.Esterilizado,
                                              TipoAtencio = a.TipoAte,
                                          }).ToArray();

                
        }

        private void BtnVolverani_Click(object sender, RoutedEventArgs e)
        {
            
            Menu men = new Menu();
            men.Visibility = Visibility.Visible;


            this.Close();
        }
    }//final
}
