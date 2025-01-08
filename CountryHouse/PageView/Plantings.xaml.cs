using CountryHouse.DataBase;
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

namespace CountryHouse
{
    /// <summary>
    /// Логика взаимодействия для Plantings.xaml
    /// </summary>
    public partial class Plantings : Page
    {
        public VMPlanting VMPlanting = new VMPlanting();
        public Plantings()
        {
            InitializeComponent();

            LoadData();
        }

        public void LoadData()
        {
            ICPlantings.ItemsSource = VMPlanting.Get();
        }
    }


}
