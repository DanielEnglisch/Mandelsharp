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
using Mandelsharp;

namespace MandelsharpGUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        decimal dx = 0;
        decimal dy = 0;
        decimal increment = 0.000001M;

        public MainWindow()
        {
            InitializeComponent();

            MainCanvas.Background = new SolidColorBrush(Colors.Red);

            
            MainCanvas.MouseDown += MainCanvas_MouseDown;
            MainCanvas.KeyDown += MainCanvas_KeyDown;

        }

        private void MainCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Right)
            {
                dx += increment;
            }
            if (e.Key == Key.Left)
            {
                dx -= increment;

            }else if(e.Key == Key.Up)
            {
                dy -= increment;
            }
            if (e.Key == Key.Down)
            {
                dy += increment;

            }

            generateImage(zoom);

        }

        static decimal zoom = 10M;

        private void MainCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            generateImage(zoom);
            zoom /= 10;
        }

        private void generateImage(decimal zoom)
        {
            int size = 100;

            WriteableBitmap bitMap = new WriteableBitmap(size, size, 96, 96, PixelFormats.Rgb24, null);

            bitMap.WritePixels(new Int32Rect(0, 0, bitMap.PixelWidth, bitMap.PixelHeight), Mandelbrot.Generate(0,0, 100, zoom, size), size * 3, 0);

            Image image = new Image();
            image.Source = bitMap;

            MainCanvas.Children.Clear();
            MainCanvas.Children.Add(image);
        }
    }
}
