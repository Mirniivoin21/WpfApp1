using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WpfApp1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand AddPhrase => new RelayCommand(() => Items.Add(MyText));

        public MainViewModel()
        {
            Items = new ObservableCollection<string>();
        }

        private string _myText;
        public string MyText
        {
            get => _myText;
            set => Set(MyText, ref _myText, value);
        }

        private ObservableCollection<string> _items;
        public ObservableCollection<string> Items
        {
            get => _items;
            set => Set(() => Items, ref _items, value);
        }
    }
}