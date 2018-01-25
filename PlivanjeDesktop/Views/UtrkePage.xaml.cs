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
    /// Interaction logic for UtrkePage.xaml
    /// </summary>
    public partial class UtrkePage : Page
    {
        public List<Race> races = new List<Race>();
        RaceViewModel rvm = new RaceViewModel();
        

        public UtrkePage(int competitionId)
        {
            InitializeComponent();
            rvm.LoadRacesByCompetition(competitionId);
            this.DataContext = rvm;
            if (UserModel.role!=null && UserModel.role.Equals("trener"))
            {
                datagridRace.ColumnFromDisplayIndex(9).Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaceModel selectedRace = (RaceModel)datagridRace.SelectedItem;
        //    PlivačiUtrka pu = new PlivačiUtrka(selectedRace.Id);
        }
    }
}
