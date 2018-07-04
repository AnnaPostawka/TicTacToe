using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using TicTacToe.ViewModels;
using TicTacToe.Views;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildAvaloniaApp().Start<MainWindow>(() => new MainWindowModel());
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI()
                .LogToDebug();
    }
}
