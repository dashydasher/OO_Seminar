using NHibernate;
using NHibernate.Linq;
using Plivanje;
using Plivanje.Models;
using Plivanje.Processors;
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

namespace PlivanjeDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Prijava : Window
    {
        public Prijava()
        {
            InitializeComponent();
            Register.Click += new RoutedEventHandler(Register_Click);
            
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Registracija reg = new Registracija();
            reg.Show();
            this.Close();


        }
    }
}
