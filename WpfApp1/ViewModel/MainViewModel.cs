using System;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WpfApp1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand AddPhrase => new RelayCommand(() => AddPhraseCommand());

        public RelayCommand Clear => new RelayCommand(() => Items.Clear());

        public RelayCommand Generate => new RelayCommand(() => GenerateCommand());

        public MainViewModel()
        {
            Items = new ObservableCollection<string>();
        }

        private void AddPhraseCommand()
        {
            if (!string.IsNullOrEmpty(MyText))
                Items.Add(MyText);
            else
                MessageBox.Show("Please input correct value", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void GenerateCommand()
        {
            Random glength = new Random();
            Random Rnd = new Random();
            string gtext = null;
            for (int i = 0; i <= glength.Next(0, Items.Count); i++)
            {
                if (i == 0)
                    gtext = Items[Rnd.Next(0, Items.Count)];
                else
                    gtext += ' ' + Items[Rnd.Next(0, Items.Count)];
            }
            GPhrase = gtext;
        }

        private string _gprase;
        public string GPhrase
        {
            get => _gprase;
            set => Set(() => GPhrase, ref _gprase, value);
        }

        private string _myText;
        public string MyText
        {
            get => _myText;
            set => Set(() => MyText, ref _myText, value);
        }

        private ObservableCollection<string> _items;
        public ObservableCollection<string> Items
        {
            get => _items;
            set => Set(() => Items, ref _items, value);
        }
    }
}