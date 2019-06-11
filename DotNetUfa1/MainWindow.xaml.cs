using System;
using System.Windows;
using System.Windows.Media;

namespace DotNetUfa1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            ColorService colorService = new ColorService();
            this.ColorfulBorder.Background = new SolidColorBrush(colorService.GetColor());

            double maxValue = new DebugExample().GetMaxValue();
            Console.WriteLine(maxValue);
        }
    }
}