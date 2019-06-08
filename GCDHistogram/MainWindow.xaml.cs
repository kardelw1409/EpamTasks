using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GCDHistogram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (firstBox.Text.Length == 0 || secondBox.Text.Length == 0)
                {
                    MessageBox.Show("Empty field");
                }
                else
                {
                    var firstNumber = uint.Parse(firstBox.Text);
                    var secondNumber = uint.Parse(secondBox.Text);
                    double timeBinaryGCD;
                    double timeEuclideanGCD;
                    var resultGCD = BinaryGCDAlgorithm.GetGreatestCommonDivisor(out timeBinaryGCD, firstNumber, secondNumber);
                    EuclideanAlgorithm.GetGreatestCommonDivisor(out timeEuclideanGCD, firstNumber, secondNumber);
                    resultBox.Text = resultGCD.ToString();
                    LoadChartData(timeBinaryGCD, timeEuclideanGCD);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Load chart in window.
        /// </summary>
        /// <param name="timeBinaryGCD">Time execution binary Euclidean algorithm.</param>
        /// <param name="timeEuclideanGCD">Time execution Euclidean algorithm.</param>
        /// <param name="isVertical">
        /// Histogram orientation. True - vertical orientation,
        /// false - horizontal orientation. True is default.
        /// </param>
        private void LoadChartData(double timeBinaryGCD, double timeEuclideanGCD, bool isVertical = true)
        {
            var keyValuePair = new KeyValuePair<string, double>[]{
                    new KeyValuePair<string,double>("Binary GCD Algorithm", timeBinaryGCD),
                    new KeyValuePair<string,double>("Euclidean Algorithm", timeEuclideanGCD)};
            if (isVertical)
            {
                
                barChart.Visibility = Visibility.Hidden;
                columnChart.Visibility = Visibility.Visible;
                ((ColumnSeries)columnChart.Series[0]).ItemsSource = keyValuePair;
            }
            else
            {
                columnChart.Visibility = Visibility.Hidden;
                barChart.Visibility = Visibility.Visible;
                ((BarSeries)barChart.Series[0]).ItemsSource = keyValuePair;
            }
        }
    }
}
