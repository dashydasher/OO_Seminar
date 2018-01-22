﻿using Plivanje.Models;
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
        }
    }
}