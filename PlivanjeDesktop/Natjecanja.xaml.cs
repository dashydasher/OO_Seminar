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
using System.Windows.Shapes;

namespace PlivanjeDesktop
{
    /// <summary>
    /// Interaction logic for Natjecanja.xaml
    /// </summary>
    /// 

    public partial class Natjecanja : Window
    {
        private List<Competition> competitions = new List<Competition>();

        CompetitionViewModel competitionViewModel;

        public Natjecanja()
        {
            InitializeComponent();

            competitionViewModel = new CompetitionViewModel();
            competitionViewModel.LoadCompetitions();
            this.DataContext = competitionViewModel;

        }
   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var competitionId = datagridC.SelectedIndex;
            if (competitionId >= 0)
            {
                var selectedCompetition = competitionViewModel.competitions.GetRange(competitionId, 1)[0];
                Utrke pl = new Utrke(selectedCompetition);
                pl.Show();
                this.Close();
            }
        }
    }
}
