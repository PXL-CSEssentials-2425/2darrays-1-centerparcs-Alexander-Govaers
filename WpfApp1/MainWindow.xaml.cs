using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int[] _numberOfDays = new int[] { 1, 2, 5, 7, 8, 12, 14, 21 };

        private string[,] _houseWithPrice = new string[5, 2] {
            { "2 personen", "80" },
             { "4 personen", "120" } ,
            { "4 personen lux", "140" } ,
              { "6 personen", "180" },
            { "8 personen", "200"}
};
        int price = 0;

        public MainWindow()
        {
            InitializeComponent();



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (int day in _numberOfDays)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = day;
                aantalDagenComboBox.Items.Add(day);
            }

            for (int i = 0; i < _houseWithPrice.GetLength(0); i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = _houseWithPrice[i, 0];
                typeWoningComboBox.Items.Add(item);

            }

           
        }



        private void GetPrice()
        {
           
            
                int aantalDagen = (int)(aantalDagenComboBox.SelectedValue);

                price = int.Parse(_houseWithPrice[typeWoningComboBox.SelectedIndex, 1]) * aantalDagen;

                priceTxtBox.Text = $"{price:c}";
            
        }

        private void typeWoningComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (aantalDagenComboBox.SelectedItem != null && typeWoningComboBox.SelectedItem != null)
            {
             
                GetPrice();
            }

        }
    }
}
