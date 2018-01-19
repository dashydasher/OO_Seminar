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
using System.Windows.Shapes;

namespace PlivanjeDesktop
{
    /// <summary>
    /// Interaction logic for Rekordi.xaml
    /// </summary>
    public partial class Rekordi : Window
    {

        private List<Record> records = new List<Record>();
        
        RecordViewModel recordViewModel;
        public Rekordi(string _value)
        {
            InitializeComponent();


                 var recordViewModel = new ViewModels.RecordViewModel();
                 //RecordViewModel.LoadRecords();
                 this.DataContext = recordViewModel;
        }
    }
}
