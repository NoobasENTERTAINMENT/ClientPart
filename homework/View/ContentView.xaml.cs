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

namespace homework.View
{
    /// <summary>
    /// Логика взаимодействия для ContentView.xaml
    /// </summary>
    public partial class ContentView : UserControl
    {
        public ContentView()
        {
            InitializeComponent();
            BooksItem.Foreground = Brushes.OrangeRed;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            BooksItem.Foreground = Brushes.OrangeRed;
            IssuancesItem.Foreground = Brushes.Black;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            IssuancesItem.Foreground = Brushes.OrangeRed;
            BooksItem.Foreground = Brushes.Black;
        }
    }
}
