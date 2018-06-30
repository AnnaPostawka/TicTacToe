using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace TicTacToe.Models
{
    public class Circle : Shape
    {
        public Circle(ContentControl drawingCanvas, Color color) : base(drawingCanvas, color)
        {
        }

        public override void Draw()
        {
            var circle = new Ellipse();
            circle.Fill = colorBrush;
            circle.Width = width;
            circle.Height = height;
            circle.Margin = margin;
            var container = new StackPanel();
            container.Children.Add(circle);
            drawingCanvas.Content = container;
        }
    }
}
