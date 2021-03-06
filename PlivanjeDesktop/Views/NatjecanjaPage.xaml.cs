﻿using Plivanje.Models;
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

        SwimmerViewModel svm = new SwimmerViewModel();

        CompetitionViewModel cvm;

        public NatjecanjaPage()
        {
            InitializeComponent();

            cvm = new CompetitionViewModel();
            cvm.LoadCompetitions();
                    
            this.DataContext = cvm;

            
            if (UserModel.role != null && UserModel.role.Equals("trener"))
            {
                trenerovaNatjecanja.Visibility = Visibility.Visible;
                orgNatjecanje.Visibility = Visibility.Visible;
                tbBegin.DisplayDateStart = DateTime.Today;
                tbEnd.DisplayDateStart = DateTime.Today;
                
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
            
            if (selectedCompetition.TimeStart < DateTime.Today && selectedCompetition.TimeEnd < DateTime.Today)
            {
                MessageBox.Show("Ovo natjecanje je završilo!");
                return;
            } else if (selectedCompetition.TimeStart <= DateTime.Today && selectedCompetition.TimeEnd >= DateTime.Today)
            {
                MessageBox.Show("Ovo natjecanje je u tijeku, prijave utrka su završile!");
                return;
            }

            UtrkePage up = new UtrkePage(selectedCompetition.Id);
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(up);
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
            if (DateTime.Parse(tbEnd.Text) < DateTime.Parse(tbBegin.Text))
            {
                MessageBox.Show("Datum završetka natjecanja mora biti nakon datuma početka natjecanja ili jednak datumu početka natjecanja!");
                return;
            }

            if (String.IsNullOrEmpty(tbHall.Text))
            {
                MessageBox.Show("Potrebno je unijeti dvoranu.");
                return;
            }

            string name = tbName.Text.Trim();
            DateTime timeStart= tbBegin.SelectedDate.Value;
            DateTime timeEnd = tbEnd.SelectedDate.Value;
            HallModel hallS = (HallModel)tbHall.SelectedValue;

            bool uspjeh = cvm.AddCompetition(name, timeStart, timeEnd, hallS); 
            if (uspjeh)
            {

                MessageBox.Show("Uspješno spremljeno natjecanje");
                NatjecanjaPage np = new NatjecanjaPage();
                NavigationService navService = NavigationService.GetNavigationService(this);
                navService.Navigate(np);

            }
            else
            {              
                MessageBox.Show("Pogreška u spremanju natjecanja");
            }

          
        }




    }
}
