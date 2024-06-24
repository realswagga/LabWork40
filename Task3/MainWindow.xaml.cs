using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Task3
{

    public partial class MainWindow : Window
    {
        Random random = new();
        List<Ellipse> ellipseList = new List<Ellipse>();
        List<Brush> brushes = new List<Brush> { Brushes.Red, Brushes.Black, Brushes.Beige, Brushes.Cyan, Brushes.Cornsilk, Brushes.Green };
        String[] tags = { "enemy", "hero", "treasure" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(this);
            ellipseList.Add(new Ellipse { Width = random.Next(60, 100), Height = random.Next(60, 100), Fill = brushes[random.Next(brushes.Count)], Tag = tags[random.Next(tags.Length)] });
            ellipseList.Last().MouseLeftButtonDown += Ellipse_MouseLeftButtonDown;
            Canvas.SetTop(ellipseList.Last(), point.Y - ellipseList.Last().Width / 2);
            Canvas.SetLeft(ellipseList.Last(), point.X - ellipseList.Last().Height / 2);
            canvas.Children.Add(ellipseList.Last());
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (sender != null)
                MessageBox.Show("Тег объекта: " + ellipse.Tag.ToString());
        }
    }
}