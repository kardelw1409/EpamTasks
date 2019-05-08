using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CoordinateSystem;

namespace WpfApplication
{
    /// <summary>
    /// The Logic of Interaction for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The constructor of the main window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Button.Click += Button_Click;
            ButtonFile.Click += ButtonFile_Click;
        }
        /// <summary>
        /// The method that opens the dialog box for selecting the txt file with the coordinate,
        /// then the data is taken from the file, formatted to the desired form 
        /// and shown in the window to display the result.
        /// </summary>
        /// <param name="sender">Event Sender.</param>
        /// <param name="e">Event Arguments.</param>
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
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// The method takes the coordinates from the input field,
        /// formats them and displays in the field to display the result.
        /// </summary>
        /// <param name="sender">Event Sender.</param>
        /// <param name="e">Event Arguments.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextInput.Text.Length == 0)
                {
                    MessageBox.Show("Empty field");
                }
                else
                {
                    TextOutput.Text = ParseStringInFormat(TextInput.Text);
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// The method finds the file in the full path, takes coordinates from it, formats
        /// and returns a formatted string with a coordinate.
        /// </summary>
        /// <param name="path">Path for file with coordinates.</param>
        /// <returns>String in format</returns>
        private string ParseStringFileInFormat(string path)
        {
            var parser = new PointsCreator();
            var fileInput = new PointsFromFileReader();
            string outputString = "";
            var points = fileInput.GetPointsList(path);
            foreach (var point in points)
            {
                outputString += string.Format($"X: {point.X} Y: {point.Y}") + "\n";
            }
            return outputString;
        }
        /// <summary>
        /// The method splits a string by NewLine, each coordinate
        /// is formatted and the result is displayed in a field for output.
        /// </summary>
        /// <param name="input">String for parse.</param>
        /// <returns>String in format</returns>
        private string ParseStringInFormat(string input)
        {
            string outputString = "";
            var parser = new PointsCreator();
            CoordinateSystem.Point point;
            string[] strings = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (var count in strings)
            {
                point = parser.CreatePoint(count);
                outputString += string.Format($"X: {point.X} Y: {point.Y}") + "\n";
            }
            return outputString;
        }
        /// <summary>
        /// The method hides the help line when clicking on the input field.
        /// </summary>
        /// <param name="sender">Event Sender.</param>
        /// <param name="e">Event Arguments.</param>
        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text == "Please enter coordinates here...")
                txtBox.Text = string.Empty;
        }

    }
}
