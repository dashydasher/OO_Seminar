using Plivanje.Models;
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
    /// Interaction logic for PlivačiPage.xaml
    /// </summary>
    public partial class PlivačiPage : Page
    {
        public List<Swimmer> swimmers = new List<Swimmer>();
        SwimmerViewModel svm = new SwimmerViewModel();
        private string v;

        public PlivačiPage(string _value)
        {
            InitializeComponent();
            var categoryName = _value.Trim().ToLower();
            svm.LoadSwimmers(categoryName);
            this.DataContext = svm;
        }


        public PlivačiPage(int clubId)
        {
            InitializeComponent();
            svm.LoadSwimmersByClub(clubId);
            this.DataContext = svm;
        }

        public PlivačiPage(int clubId, string role)
        {
            if (role.Equals("trener"))
            {
                InitializeComponent();
                svm.LoadCoachesSwimmersByClub(clubId);
                svm.LoadSwimmersWithoutClub();
                trenerPanel.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
