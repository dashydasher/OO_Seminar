using Plivanje.Models;
using PlivanjeDesktop.Models;
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
        SwimmerViewModel svm = new SwimmerViewModel();

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

            if (UserModel.role.Equals("trener"))
            {
                trenerPanel.Visibility = Visibility.Visible;
                datagridSwimmer.ColumnFromDisplayIndex(4).Visibility = Visibility.Collapsed;
                datagridSwimmer.ColumnFromDisplayIndex(6).Visibility = Visibility.Visible;
            }
        }

        private void Button_Uclani_Click(object sender, RoutedEventArgs e)
        {
            SwimmerModel selectedSwimmer = (SwimmerModel)datagridSwimmer.SelectedItem;
            var success = svm.AddSwimmerToClub(selectedSwimmer);
            if (success)
                MessageBox.Show("Plivač je uspješno dodan u klub");
            else
                MessageBox.Show("Plivač nije dodan u klub");
            
            PlivačiPage pl = new PlivačiPage(svm.clubId);
            this.NavigationService.Navigate(pl);
        }

        private void Button_Isclani_Click(object sender, RoutedEventArgs e)
        {
            SwimmerModel selectedSwimmer = (SwimmerModel)datagridClubSwimmers.SelectedItem;
            bool success = svm.DeleteSwimmerFromClub(selectedSwimmer);
            if (success)
                MessageBox.Show("Plivač je uspješno iščlanjen iz kluba");
            else
                MessageBox.Show("Plivač nije iščlanjen iz kluba");
            
            PlivačiPage pl = new PlivačiPage(svm.clubId);
            this.NavigationService.Navigate(pl);
        }
    }
}
