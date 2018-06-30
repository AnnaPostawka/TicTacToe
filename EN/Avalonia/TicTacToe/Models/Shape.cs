using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Models
{
    public abstract class Shape
    {
        protected ContentControl drawingCanvas;
        protected SolidColorBrush colorBrush = new SolidColorBrush();
        protected Int32 width = 400;
        protected Int32 height = 400;
        protected Thickness margin = new Thickness(0, 50, 0, 0);

        protected Shape(ContentControl drawingCanvas, Color color)
        {
            this.drawingCanvas = drawingCanvas;
            colorBrush.Color = color;
        }

        public abstract void Draw();
    }
}
