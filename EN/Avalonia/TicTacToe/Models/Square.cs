using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace TicTacToe.Models
{
    public class Square : Shape
    {
        public Square(ContentControl drawingCanvas, Color color) : base(drawingCanvas, color)
        {
        }

        public override void Draw()
        {
            var square = new Rectangle();
            square.Fill = colorBrush;
            square.Width = width;
            square.Height = height;
            square.Margin = margin;
            var container = new StackPanel();
            container.Children.Add(square);
            drawingCanvas.Content = container;
        }
    }
}
