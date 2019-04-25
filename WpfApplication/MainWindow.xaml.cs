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
using CoordinateSystem;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button.Click += Button_Click1;

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            var parser = new PointParser();
            string input = TextInput.Text;
            TextOutput.Text = parser.OutputPoint(parser.InputPoint(input));

        }


    }
}
