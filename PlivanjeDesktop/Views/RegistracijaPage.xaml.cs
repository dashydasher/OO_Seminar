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
        public RegistracijaPage()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, RoutedEventArgs e)
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
            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Potrebno je unijeti lozinku.");
                return;
            }
            if (String.IsNullOrEmpty(textBoxIdLicence.Text))
            {
                MessageBox.Show("Potrebno je unijeti ID licence.");
                return;
            }

            string firstName = textBoxName.Text.Trim();
            string lastName = textBoxSurname.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string IdLicence = textBoxIdLicence.Text.Trim();

            //var licenceProcessor = new LicenceProcessor();
        }
    }
}
