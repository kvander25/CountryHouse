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
using static System.Net.Mime.MediaTypeNames;

namespace CountryHouse
{
    /// <summary>
    /// Логика взаимодействия для Buildings.xaml
    /// </summary>
    public partial class Buildings : Page
    {
        public VMBuildings VMBuildings = new VMBuildings();
        public Buildings()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            StackPanel st;
            //ICBuildings.ItemsSource = VMBuildings.Get();
            foreach(DateBuildings data in VMBuildings.Get())
            {
                st = new StackPanel() { Margin = new Thickness(5), Orientation = Orientation.Vertical};
                st.MouseDown += StackPanel_MouseDown;
                st.Children.Add(new TextBlock
                {
                    Text = "Наименование: "+data.Name, Margin = new Thickness(3)
                });
                st.Children.Add(new TextBlock
                {
                    Text = "Статус: " + data.Status,
                    Margin = new Thickness(3)
                });
                st.Children.Add(new TextBlock
                {
                    Text = "Дата постройки: " + data.DateBuild.ToString("dd:MM:yyyy"),
                    Margin = new Thickness(3)
                });
                st.Children.Add(new TextBlock
                {
                    Text = "Тип постройки: " + data.TypeBuild,
                    Margin = new Thickness(3)
                });
                wp.Children.Add (st);
            }
            
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (StackPanel item in wp.Children)
            {
                item.Background = null;
            }
            StackPanel st = sender as StackPanel;
            st.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#4C00842C");
            
        }
    }
    
}
