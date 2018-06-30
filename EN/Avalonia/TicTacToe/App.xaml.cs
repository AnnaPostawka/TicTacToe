using Avalonia;
using Avalonia.Markup.Xaml;

namespace TicTacToe
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}