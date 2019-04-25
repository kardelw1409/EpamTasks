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
        /// <summary>
        /// Метод, в котором инициализируются компоненты главного окна,
        /// а также "вешаются" обработчики событий для кнопок главного окна.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Button.Click += Button_Click;
            ButtonFile.Click += ButtonFile_Click;    
        }
        /// <summary>
        /// Метод, открывающий диалоговое окно для выбора txt файла с координатоми,
        /// далее данные берутся из файла, форматируются к нужному виду и показываются в окне для вывода результата.
        /// </summary>
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
        /// <summary>
        /// Метод, который берет координаты из поля для ввода, форматирует координаты и
        /// показывает их в окне для вывода результата. 
        /// </summary>
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
        /// <summary>
        /// Метод находит по полному пути файл, забирает из него коорлинаты, форматирует
        /// и возвращает полностью готовую отформатированную строку с координатоми.
        /// </summary>
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
        /// <summary>
        /// Метод разбивает строку по NewLine (начало новой строки), каждая координата
        /// форматируется и результат выводится в окно для вывода.
        /// </summary>
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
