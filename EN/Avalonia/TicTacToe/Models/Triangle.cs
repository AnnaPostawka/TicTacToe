using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace TicTacToe.Models
{
    public class Triangle : Shape
    {
        public Triangle(ContentControl drawingCanvas, Color color) : base(drawingCanvas, color)
        {
        }

        public override void Draw()
        {
            var triangle = new Polygon();
            triangle.Points = new List<Point>
            {
                new Point(300, 200),
                new Point(400, 125),
                new Point(400, 275),
                new Point(300, 200)
            };
            triangle.Fill = colorBrush;
            triangle.Width = width;
            triangle.Height = height;
            triangle.Stretch = Stretch.Fill;
            triangle.Margin = margin;
            var container = new StackPanel();
            container.Children.Add(triangle);
            drawingCanvas.Content = container;
        }
    }
}
