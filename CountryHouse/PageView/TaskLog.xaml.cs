﻿using CountryHouse.DataBase;
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
    /// Логика взаимодействия для TaskLog.xaml
    /// </summary>
    public partial class TaskLog : Page
    {
        public VMTaskLog VMTaskLog = new VMTaskLog();
        public TaskLog()
        {
            InitializeComponent();

            LoadData();
        }

        public void LoadData()
        {
            ICTaskLog.ItemsSource = VMTaskLog.Get();
        }
    }

}
