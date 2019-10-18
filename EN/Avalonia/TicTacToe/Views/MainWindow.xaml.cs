using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using TicTacToe.ViewModels;

namespace TicTacToe.Views
{
    public class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void OnButtonClicked(object sender, RoutedEventArgs args)
        {
            var context = this.DataContext as MainWindowModel;
            context.Greeting = $"Hello {context.Name}";
        }
    }
}