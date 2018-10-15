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
        public MainWindow()
        {
            InitializeComponent();

            MainCanvas.Background = new SolidColorBrush(Colors.Red);

            int size = 500;

            WriteableBitmap bitMap = new WriteableBitmap(size, size, 96,96,PixelFormats.Rgb24,null);
        
            bitMap.WritePixels(new Int32Rect(0, 0, bitMap.PixelWidth, bitMap.PixelHeight), Mandelbrot.Generate(size), size * 3, 0);

            Image image = new Image();
            image.Source = bitMap;

            MainCanvas.Children.Add(image);

        }

      

    }
}
