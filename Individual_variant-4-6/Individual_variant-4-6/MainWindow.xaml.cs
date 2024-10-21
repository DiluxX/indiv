using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Individual_variant_4_6
{
    public partial class MainWindow : Window
    {
        private double radius = 0;
        private bool calculateArea = false;
        private bool calculateLength = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            InputDialog inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == true)
            {
                radius = inputDialog.Radius;
                calculateArea = inputDialog.CalculateArea;
                calculateLength = inputDialog.CalculateLength;
            }
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            string result = "Results:\n";

            if (calculateArea)
            {
                double area = Math.PI * radius * radius;
                result += $"Area of the circle: {area}\n";
            }

            if (calculateLength)
            {
                double length = 2 * Math.PI * radius;
                result += $"Circumference of the circle: {length}\n";
            }

            MessageBox.Show(result, "Calculation Results");
        }

        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();
            if (radius > 0 && (radius * 2) <= DrawingCanvas.ActualWidth && (radius * 2) <= DrawingCanvas.ActualHeight)
            {
                var circle = new Ellipse
                {
                    Width = radius * 2,
                    Height = radius * 2,
                    Fill = Brushes.Blue,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                Canvas.SetLeft(circle, (DrawingCanvas.ActualWidth - circle.Width) / 2);
                Canvas.SetTop(circle, (DrawingCanvas.ActualHeight - circle.Height) / 2);
                DrawingCanvas.Children.Add(circle);
            }
            else
            {
                MessageBox.Show("нельзя т.к размер не подходит", "Error");
            }
        }
    }
}