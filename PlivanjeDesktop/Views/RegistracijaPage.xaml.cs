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
            if (String.IsNullOrEmpty(textBoxIdLicence.Text))
            {
                MessageBox.Show("Potrebno je unijeti ID licence.");
                return;
            }
            string role = (trenerRadio.IsChecked==true)?"trener":"sudac";
            string firstName = textBoxName.Text.Trim();
            string lastName = textBoxSurname.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Password.Trim();
            string idLicence = textBoxIdLicence.Text.Trim();

            bool uspjeh = rvm.RegisterPerson(role, firstName, lastName, email, password, idLicence);
            if (!uspjeh)
                MessageBox.Show("Licenca je nevažeća");
            else
            {
                //preusmjeravanje na stranicu kao nakon prijave
            }
        }
    }
}
