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
    /// Interaction logic for PrijavaPage.xaml
    /// </summary>
    public partial class PrijavaPage : Page
    {
        public PrijavaPage()
        {
            InitializeComponent();
            Register.Click += new RoutedEventHandler(Register_Click);

        }
  
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            RegistracijaPage r = new RegistracijaPage();
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(r);

        }

        private void PrijaviSe_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Potrebno je unijeti e-mail.");
                return;
            }
            if (String.IsNullOrEmpty(textBoxPassword.Password))
            {
                MessageBox.Show("Potrebno je unijeti lozinku.");
                return;
            }
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Password.Trim();
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
                        KluboviPage k = new KluboviPage(trener.Id, "trener");
                        NavigationService navService = NavigationService.GetNavigationService(this);
                        navService.Navigate(k);
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
                        NatjecanjaPage n = new NatjecanjaPage();
                        NavigationService navService = NavigationService.GetNavigationService(this);
                        navService.Navigate(n);

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
