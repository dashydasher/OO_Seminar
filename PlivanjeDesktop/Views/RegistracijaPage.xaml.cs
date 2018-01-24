using PlivanjeDesktop.ViewModels;
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
    /// Interaction logic for RegistracijaPage.xaml
    /// </summary>
    public partial class RegistracijaPage : Page
    {

        RegisterViewModel rvm = new RegisterViewModel();

        public RegistracijaPage()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Potrebno je unijeti ime.");
                return;
            }
            if (String.IsNullOrEmpty(textBoxSurname.Text))
            {
                MessageBox.Show("Potrebno je unijeti prezime.");
                return;
            }
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
            
            string role = (trenerRadio.IsChecked==true)?"trener":"sudac";
            string firstName = textBoxName.Text.Trim();
            string lastName = textBoxSurname.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Password.Trim();
            DateTime dateOfBirth = tbDate.DisplayDate.Date;

            bool uspjeh = rvm.RegisterPerson(role, firstName, lastName, email, password, dateOfBirth);
            if (uspjeh)
            {
                MessageBox.Show("Registracija je uspješna. Moći ćete se prijaviti nakon što Vam se dodjeli licenca.");
                NatjecanjaPage np = new NatjecanjaPage();
                NavigationService navService = NavigationService.GetNavigationService(this);
                navService.Navigate(np);
            }
            else
            {
                MessageBox.Show("Registracija neuspješna.");
            }
        }
    }
}
