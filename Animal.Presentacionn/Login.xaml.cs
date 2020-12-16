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
using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;



namespace Animal.Presentacionn
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        public int aa = 0;
        public Login()
        {
           InitializeComponent();
           ThemeManager.Current.ChangeTheme(this, "Dark.Green");

        }
        public void Limpiar()
        {
            txtUser.Text = string.Empty;
            txtPass.Password = string.Empty;
            txtUser.Focus();
        }

        private async void BtnAceptarUser_Click(object sender, RoutedEventArgs e)
        {
            Usuario sesion = new Usuario(txtArea.Text, txtUser.Text, txtPass.Password);
            if (sesion.Leer())
            {
                
                await this.ShowMessageAsync("Bienvenido", "Que tengas un buen dia ");
                
                Menu men = new Menu();
                men.Visibility = Visibility.Visible;

                this.Close();

            }
            else
            {
                MessageBox.Show("Contraseña Incorrecta", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                aa++;
                Limpiar();
            }
            if (aa == 3)
            {
                MessageBox.Show("Demasiados Intentos, Ingreso no permitido");
                App.Current.Shutdown();
            }
        }

    }
 }

