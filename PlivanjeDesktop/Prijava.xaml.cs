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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //ObjectQuery<Category> categories = dataEntities.Products;

            //var query =
            //from product in products
            //where product.Color == "Red"
            //orderby product.ListPrice
            //select new { product.Name, product.Color, CategoryName = product.ProductCategory.Name, product.ListPrice };

            //dataGrid1.ItemsSource = query.ToList();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Registracija r = new Registracija();
            r.Show();
            this.Close();


        }

        private void MenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            mi.IsSubmenuOpen = true;
        }

        private void MenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            mi.IsSubmenuOpen = false;
        }

        private void Competition_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Natjecanja n = new Natjecanja();
            n.Show();
            this.Close();
        }

        private void Clubs_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Klubovi k = new Klubovi();
            k.Show();
            this.Close();
        }

        private void Swimmers_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            MenuItem mi = sender as MenuItem;
            Plivači p = new Plivači(mi.Header.ToString());
            p.Show();
            this.Close();
        }

        private void Records_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            MenuItem mi = sender as MenuItem;
            Rekordi r = new Rekordi(mi.Header.ToString());
            r.Show();
            this.Close();
        }
    }
}
