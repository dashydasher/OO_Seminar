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
        public List<Hall> halls;
        
        SwimmerViewModel svm = new SwimmerViewModel();
        CompetitionViewModel cvm;
        public NatjecanjaPage()
        {
            InitializeComponent();

            cvm = new CompetitionViewModel();
            cvm.LoadCompetitions();
            if (UserModel.role != null && UserModel.role.Equals("trener"))
            {
                cvm.LoadCoachesCompetitions(UserModel.Id);
                cvm.LoadPossibleHalls(UserModel.Id);
            }

            this.DataContext = cvm;
            
            if (UserModel.role != null && UserModel.role.Equals("trener"))
            {
                trenerovaNatjecanja.Visibility = Visibility.Visible;
                orgNatjecanje.Visibility = Visibility.Visible;
            }

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

        private void Dodaj_Utrke(object sender, RoutedEventArgs e)
        {
            CompetitionModel selectedCompetition = (CompetitionModel)datagrid1.SelectedItem;
            UtrkePage up = new UtrkePage(selectedCompetition.Id);
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(up);
        }

        private void datagridC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Dodaj_Natjecanje(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Potrebno je unijeti naziv natjecanja.");
                return;
            }
            if (String.IsNullOrEmpty(tbBegin.Text))
            {
                MessageBox.Show("Potrebno je unijeti vrijeme početka održavanja natjecanja.");
                return;
            }
            if (String.IsNullOrEmpty(tbEnd.Text))
            {
                MessageBox.Show("Potrebno je unijeti vrijeme završetka natjecanja.");
                return;
            }
            if (String.IsNullOrEmpty(tbHall.Text))
            {
                MessageBox.Show("Potrebno je unijeti dvoranu.");
                return;
            }
         
            string name = tbName.Text.Trim();
            DateTime timeStart= tbBegin.DisplayDate.Date;
            DateTime timeEnd = tbEnd.DisplayDate.Date;
            HallModel hallS = (HallModel)tbHall.SelectedValue;

            bool uspjeh = cvm.AddCompetition(name, timeStart, timeEnd, hallS); 
            if (uspjeh)
            {
                //datagrid1.Items.Refresh();
                //datagridC.Items.Refresh();
                MessageBox.Show("Uspješno spremljeno natjecanje");


                NatjecanjaPage np = new NatjecanjaPage();
                NavigationService navService = NavigationService.GetNavigationService(this);
                navService.Navigate(np);

                //BindingExpression binding = datagrid1.GetBindingExpression(DataGrid.ItemsSourceProperty);
                //binding.UpdateSource();
                //BindingExpression binding2 = datagridC.GetBindingExpression(DataGrid.ItemsSourceProperty);        
                //binding2.UpdateSource();


                //datagrid1.ItemsSource = null;
                // datagrid1.ItemsSource = coachesCompetitions;
                //datagridC.ItemsSource = null;
                //datagridC.ItemsSource = competitions;
               


            }
            else
            {              
                MessageBox.Show("Pogreška u spremanju natjecanja");
            }

          
        }




    }
}
