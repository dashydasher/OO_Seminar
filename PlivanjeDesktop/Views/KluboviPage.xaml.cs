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
    /// Interaction logic for KluboviPage.xaml
    /// </summary>
    public partial class KluboviPage : Page
    {
        private List<Club> clubs = new List<Club>();

        ClubViewModel clubViewModel = new ClubViewModel();

        public KluboviPage()
        {
            InitializeComponent();
            
            clubViewModel.LoadClubs();
            this.DataContext = clubViewModel;


        }
        public KluboviPage(int id, string role)
        {
            InitializeComponent();
            
            clubViewModel.LoadClubs();
            clubViewModel.LoadCoachesClub(id);
            this.DataContext = clubViewModel;
            ButtonAddClub.Visibility = Visibility.Visible;
            trenerKlub.Visibility = Visibility.Visible;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            ClubModel selectedClub = (ClubModel)datagrid.SelectedItem;
            try
            {
                PlivačiPage pl = new PlivačiPage(selectedClub.Id);
                NavigationService navService = NavigationService.GetNavigationService(this);
                navService.Navigate(pl);
            }
            catch (Exception exc) { }
        }

        private void Dodaj_Plivače(object sender, RoutedEventArgs e)
        {
            ClubModel selectedClub = (ClubModel)datagrid1.SelectedItem;
            PlivačiPage pl = new PlivačiPage(selectedClub.Id, "trener");
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(pl);
        }
    }
}
