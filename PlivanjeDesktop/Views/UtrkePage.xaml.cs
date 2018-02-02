using Plivanje.Models;
using PlivanjeDesktop.Models;
using PlivanjeDesktop.ViewModels;
using PlivanjeDesktop.Views;
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
        int competitionId = -1;

        public UtrkePage(int competitionId)
        {
            InitializeComponent();
            rvm.LoadRacesByCompetition(competitionId);
            this.DataContext = rvm;
            this.competitionId = competitionId;

            if (UserModel.role!=null && UserModel.role.Equals("trener"))
            {
                datagridRace.ColumnFromDisplayIndex(10).Visibility = Visibility.Collapsed;
                datagridRace.ColumnFromDisplayIndex(9).Visibility = Visibility.Visible;
                if (rvm.isMyCompetition)
                    dodajUtrku.Visibility = Visibility.Visible;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaceModel selectedRace = (RaceModel)datagridRace.SelectedItem;
            PlivačiUtrka pu = new PlivačiUtrka(selectedRace.Id);
            pu.Show();
        }

        private void Button_Race_Click(object sender, RoutedEventArgs e)
        {
            RaceModel selectedRace = (RaceModel)datagridRace.SelectedItem;
            if (UserModel.role!=null && selectedRace.Referee.Id!=UserModel.Id)
            {
                MessageBox.Show("Možete mijenjati samo utrke na kojima ste sudili.");
                return;
            }
            PlivačiUtrka pu = new PlivačiUtrka(selectedRace.Id);
            pu.Show();
        }



        private void Dodaj_Utrku(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbLength.Text))
            {
                MessageBox.Show("Potrebno je unijeti duljinu utrke.");
                return;
            }
            if (String.IsNullOrEmpty(tbStyle.Text))
            {
                MessageBox.Show("Potrebno je unijeti stil utrke.");
                return;
            }
            if (String.IsNullOrEmpty(tbEnd.Text))
            {
                MessageBox.Show("Potrebno je unijeti vrijeme završetka utrke.");
                return;
            }

           
            if (String.IsNullOrEmpty(tbBegin.Text))
            {
                MessageBox.Show("Potrebno je unijeti vrijeme početka održavanja utrke.");
                return;
            }
            if (String.IsNullOrEmpty(tbEnd.Text))
            {
                MessageBox.Show("Potrebno je unijeti vrijeme završetka utrke.");
                return;
            }

            if (String.IsNullOrEmpty(tbCategory.Text))
            {
                MessageBox.Show("Potrebno je unijeti kategoriju utrke.");
                return;
            }

            if (String.IsNullOrEmpty(tbPool.Text))
            {
                MessageBox.Show("Potrebno je unijeti bazen.");
                return;
            }

            if (String.IsNullOrEmpty(tbReferee.Text))
            {
                MessageBox.Show("Potrebno je unijeti suca utrke.");
                return;
            }

            string gender = (zeneRadio.IsChecked == true) ? "Ž" : "M";           
            LengthModel len = (LengthModel)tbLength.SelectedValue;
            StyleModel style = (StyleModel)tbStyle.SelectedValue;
            DateTime timeStart = tbBegin.DisplayDate.Date;
            DateTime timeEnd = tbEnd.DisplayDate.Date;
            PersonModel referee = (PersonModel)tbReferee.SelectedValue;
            PoolModel pool = (PoolModel)tbPool.SelectedValue;
            CategoryModel category = (CategoryModel)tbCategory.SelectedValue;

            bool uspjeh = rvm.AddRace(gender, len.Id, style.Id, timeStart, timeEnd, referee.Id, competitionId, pool.Id, category.Id);
            if (uspjeh)
            {
             
                MessageBox.Show("Uspješno spremljena utrka");
                
                UtrkePage up = new UtrkePage(competitionId);
                NavigationService navService = NavigationService.GetNavigationService(this);
                navService.Navigate(up);

            }
            else
            {
                MessageBox.Show("Pogreška u spremanju utrke");
            }


        }
    }
}
