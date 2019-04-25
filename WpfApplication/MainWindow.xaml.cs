using System;
using System.Windows;
using System.Windows.Controls;
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
            Button.Click += Button_Click;
            ButtonFile.Click += ButtonFile_Click;    
        }

        private void ButtonFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            try
            {
                bool? result = openFileDlg.ShowDialog();
                if (result == true)
                {
                    TextOutput.Text = ParseStringFileInFormat(openFileDlg.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в программе");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextInput.Text.Length == 0)
                {
                    MessageBox.Show("Пустое поле");
                }
                else
                {
                    TextOutput.Text = ParseStringInFormat(TextInput.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в программе");
            }
        }

        private string ParseStringFileInFormat(string path)
        {
            var parser = new PointParser();
            FileInputPoint fileInput;
            CoordinateSystem.Point point;
            string outputString = "";
            using (fileInput = new FileInputPoint(path))
            {
                while (true)
                {
                    point = fileInput.InputPoint();
                    if (point == null) break;
                    outputString += parser.OutputPoint(point) + "\n";
                }
            }
            return outputString;
        }

        private string ParseStringInFormat(string input)
        {
            string outputString = "";
            var parser = new PointParser();
            CoordinateSystem.Point point;
            string[] strings = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (var count in strings)
            {
                point = parser.InputPoint(count);
                if (point == null) break;
                outputString += parser.OutputPoint(point) + "\n";
            }
            return outputString;
        }


    }
}
