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
    /// Interaction logic for NatjecanjaPage.xaml
    /// </summary>
    public partial class NatjecanjaPage : Page
    {
        private List<Competition> competitions = new List<Competition>();

        CompetitionViewModel competitionViewModel;

        public NatjecanjaPage()
        {
            InitializeComponent();

            competitionViewModel = new CompetitionViewModel();
            competitionViewModel.LoadCompetitions();
            this.DataContext = competitionViewModel;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            CompetitionModel selectedCompetition = (CompetitionModel)datagridC.SelectedItem;
            try
            {
                UtrkePage up = new UtrkePage(selectedCompetition.Id);
                NavigationService navService = NavigationService.GetNavigationService(this);
                navService.Navigate(up);
            }
            catch (Exception exc) { }
        }
        
    }
}
