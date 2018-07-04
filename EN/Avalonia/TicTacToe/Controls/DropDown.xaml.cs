using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TicTacToe.Controls
{
    public class DropDown : UserControl
    {
        public DropDown()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
