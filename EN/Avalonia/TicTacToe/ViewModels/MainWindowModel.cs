using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TicTacToe.ViewModels
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        private string _greeting;
        private string _name;

        public string Greeting
        {
            get => _greeting;
            set
            {
                if (value != _greeting)
                {
                    _greeting = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    //public class MainWindowModel : ViewModelBase
    //{
    //    public string NameOfTheGame => "Tic Tac Toe";
    //}
}
