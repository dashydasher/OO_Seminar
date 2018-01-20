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
    /// Interaction logic for Rekordi.xaml
    /// </summary>
    public partial class Rekordi : Window
    {

        public List<Record> records = new List<Record>();

        public Rekordi(string _value)
        {
            InitializeComponent();

            RecordViewModel rvm = new RecordViewModel();
            var gender = _value.Trim().ToLower();
            rvm.LoadRecords(gender);
            this.DataContext = rvm;
        }

        public Rekordi(List<Record> rekordi)
        {
            InitializeComponent();
            records.AddRange(rekordi);
        }


    }
}
