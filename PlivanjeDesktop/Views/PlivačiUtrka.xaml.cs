﻿using Plivanje.Processors;
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
using System.Windows.Shapes;

namespace PlivanjeDesktop.Views
{
    /// <summary>
    /// Interaction logic for PlivačiUtrka.xaml
    /// </summary>
    public partial class PlivačiUtrka : Window
    {
        public PlivačiUtrka(int raceId)
        {
            InitializeComponent();
            var svm = new SwimmerViewModel();
            var cp = new ClubProcessor();
            svm.LoadSwimmersByClub(cp.getMyClubId(UserModel.Id));
            this.DataContext = svm;
        }

        private void Button_Prijavi_Click(object sender, RoutedEventArgs e)
        {
            //foreach ()
            this.Close();
        }
    }
}
