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

namespace Drawing_on_the_Canvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point currentPoint = new Point();
        Brush brushColour = System.Windows.Media.Brushes.Black;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Image image = new Image();
            BitmapImage imageBrush = new BitmapImage();
            imageBrush.BeginInit();
            imageBrush.UriSource = new Uri(@"C:\Users\s2201087\OneDrive - Notre Dame Catholic Sixth Form College\downloads\smiley-grin.png");
            imageBrush.EndInit();
            image.Source = imageBrush;
            
            image.Width = 20; image.Height = 20;

            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(paintSurface);
                Canvas.SetTop(image, currentPoint.Y);
                Canvas.SetLeft(image, currentPoint.X);
                paintSurface.Children.Add(image);   
        }
        
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                Line line = new Line();


                line.Stroke = brushColour;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(paintSurface).X;
                line.Y2 = e.GetPosition(paintSurface).Y;   

                currentPoint = e.GetPosition(paintSurface);

                paintSurface.Children.Add(line);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            paintSurface.Children.Clear();
        }

        private void btnPenColour_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            brushColour = button.Background;
        }

        private void btnPenDraw_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
