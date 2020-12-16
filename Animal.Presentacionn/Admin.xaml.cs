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
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;





namespace Animal.Presentacionn
{
    /// <summary>
    /// Lógica de interacción para Admin.xaml
    /// </summary>
    public partial class Admin : MetroWindow
    {
        
        public Admin()
        {
            InitializeComponent();
            //ThemeManager.Current.ChangeTheme(this, "Dark.Blue");
        }
         public void Limpiar ()
        {
            txtArea.Text = string.Empty;
            txtUser.Text = string.Empty;
            txtPass.Password = string.Empty;
            
        }

        private async void BtnAgregarUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario user = new Usuario(
                    txtArea.Text,
                    txtUser.Text,
                    txtPass.Password
                 
                    );

                if (user.Create())
                {
                    await this.ShowMessageAsync("Felicidades", "Usuario Agregado");
                }
                else
                {
                    await this.ShowMessageAsync("Error", "No se puede agregar Usuario");
                }
                Limpiar();
        
            }
            catch ( Exception zz)
            {
                MessageBox.Show(zz.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private async void BtnEliminarUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario user = new Usuario()
                {
                    Name = txtUser.Text,
                };
                if (user.Delete())
                {

                    await this.ShowMessageAsync("Tarea Terminada", "Usuario Eliminado");
                }
                
                else
                {
                    await this.ShowMessageAsync("Error", "No se puede eliminar usuario");
                }
                Limpiar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void BtnVerUsuarios_Click(object sender, RoutedEventArgs e)
        {
            Manejadora mane = new Manejadora();
            dtgUsuarios.ItemsSource = (from en in mane.ListarUser ()
                                     select new
                                     {
                                         Area = en.Username,
                                         Name = en.Name,
                                     }).ToList();
        }

        private void BtnVolverAdmin_Click(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Visibility = Visibility.Visible;

            this.Close();

        }
    }
}
