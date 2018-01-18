
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
          



        }

        private void PrijaviSe_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxEmail.Text)) {
                MessageBox.Show("Potrebno je unijeti e-mail.");
                return;
            }
            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Potrebno je unijeti lozinku.");
                return;
            }
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            var cp = new CoachProcessor();
            List<Coach> treneri = cp.getCoaches();
            var rf = new RefereeProcessor();
            List<Referee> suci = rf.getReferees();

            
            foreach (var trener in treneri)
            {
                if (email.Equals(trener.EMail.Trim()))
                    if (password.Equals(trener.Password.Trim()))
                    {
                        e.Handled = true;
                        Klubovi k = new Klubovi(trener.Id, "trener");
                        k.Show();
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Pogrešna lozinka");
                        break;
                    }
            }
            foreach (var sudac in suci)
            {
                if (email.Equals(sudac.EMail))
                    if (password.Equals(sudac.Password))
                    {
                        e.Handled = true;
                        Natjecanja n = new Natjecanja();
                        n.Show();
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Pogrešna lozinka");
                        break;
                    }
            }
            MessageBox.Show("Pogrešna e-mail adresa");

        }
    }
}
