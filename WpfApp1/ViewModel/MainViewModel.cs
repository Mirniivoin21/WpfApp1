using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;

namespace WpfApp1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
        }

        public ObservableCollection<string> Items { get; set; } = new ObservableCollection<string>();

        public ICommand AddPhrase
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Items.Add(MyText);
                });
            }
        }

        public string MyText
        {
            get;
            set;
        }

        //private ObservableCollection<string> _items;
        //public ObservableCollection<string> Items
        //{
        //    get => _items;
        //    set { _items = value; RaisePropertyChanged(()=>Items); }
        //}
    }

    internal class ActionCommand : ICommand
    {
        private readonly Action action;

        public ActionCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}