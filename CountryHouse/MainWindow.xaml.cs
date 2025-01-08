using CountryHouse.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private Buildings buildings;
        private Plantings plantings;
        private TaskLog taskLog;


        public MainWindow()
        {
            InitializeComponent();
            using (DBCountryHouse DB = new DBCountryHouse())
            {
                #region AddDateIfNullBuildings
                if (DB.Buildings.ToList().Count == 0)
                {
                    DB.Buildings.Add(new DateBuildings
                    {
                        Name = "Оранжерея",
                        DateBuild = DateTime.Today,
                        Status = "Тестовый пример",
                        TypeBuild = "Тестовая постройка"
                    });
                    DB.Buildings.Add(new DateBuildings
                    {
                        Name = "Дом",
                        DateBuild = DateTime.Today,
                        Status = "Тестовый пример",
                        TypeBuild = "Тестовая постройка"
                    });
                    DB.Buildings.Add(new DateBuildings
                    {
                        Name = "Грядка",
                        DateBuild = DateTime.Today,
                        Status = "Тестовый пример",
                        TypeBuild = "Тестовая постройка"
                    });
                    DB.SaveChanges();
                }
                #endregion AddDateIfNullBuildings

                if (DB.TaskLog.ToList().Count == 0)
                {
                    DB.TaskLog.Add(new DateTaskLog { IdBuilds = 1,
                    });
                }
            }
        }


        #region PageView

        enum StatusPage
        {
            Null = 0,
            Page1 = 1,
            Page2 = 2,
            Page3 = 3            
        }
        StatusPage statusPage = StatusPage.Null;

        private void SelectView(object sender, RoutedEventArgs e)
        {
            Button but = (Button)sender;
            int Context = Convert.ToInt32(but.DataContext);
            switch (Context)
            {
                case 1:
                    statusPage = StatusPage.Page1;
                    ClearFrame();
                    buildings = new Buildings();
                    Label.NavigationService.Navigate(buildings); break;
                case 2:
                    statusPage = StatusPage.Page2;
                    ClearFrame();
                    plantings = new Plantings();
                    Label.NavigationService.Navigate(plantings); break;
                case 3:
                    statusPage = StatusPage.Page3;
                    ClearFrame();
                    taskLog = new TaskLog();
                    Label.NavigationService.Navigate(taskLog); break;
            }
        }

        private void ClearFrame()
        {
            while (Label.NavigationService.RemoveBackEntry() != null)
                Label.NavigationService.RemoveBackEntry();
        }
        #endregion PageView

        private void AddDate(object sender, RoutedEventArgs e)
        {
            switch (statusPage)
            {
                case StatusPage.Null:  break;
                case StatusPage.Page1:  buildings.VMBuildings.Add("Недавно добавил", "Так могу", DateTime.Now, "Декоративное"); 
                                        buildings.LoadData(); 
                                        break;
                case StatusPage.Page2:  plantings.VMPlanting.Add(1, "Помидоры экспериментальные", 10, DateTime.Now);
                                        plantings.LoadData(); 
                                        break;
                case StatusPage.Page3:  taskLog.VMTaskLog.Add(1, "Ремонт фасада", "Гвозди тестовые", DateTime.Now);
                                        taskLog.LoadData();
                                        break;
            }
        }

        private void EditDate(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveDate(object sender, RoutedEventArgs e)
        {

        }
    }
}
