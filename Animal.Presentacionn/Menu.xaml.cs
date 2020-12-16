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
using ControlzEx.Theming;



namespace Animal.Presentacionn
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : MetroWindow
    {
      
        public Menu()
        {
            InitializeComponent();

        }
     


        private void BtnCliente_Click(object sender, RoutedEventArgs e)
        {
            cliente cli = new cliente();
            cli.Visibility = Visibility.Visible;

            this.Close();
        }
        private void BtnMascota_Click(object sender, RoutedEventArgs e)
        {
          
            MainWindow mas = new MainWindow();
            mas.Visibility = Visibility.Visible;


            this.Close();
        }
        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
           
            Admin ad = new Admin();
            ad.Visibility = Visibility.Visible;


            this.Close();
        }

    }
}
