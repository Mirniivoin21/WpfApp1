using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WpfApp1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //private RelayCommand _addPhrase;
        //public RelayCommand AddPhrase
        //{
        //    get { return _addPhrase ?? (_addPhrase = new RelayCommand(() =>
        //    {
        //        Items.Add(MyText);
        //        MyText = null;
        //    })); }
        //}

        //public RelayCommand AddPhrase
        //{
        //    get
        //    {
        //        if (_myText != null)
        //        {
        //            return new RelayCommand(() => Items.Add(MyText));
        //        }
        //        else
        //        {
        //            return new RelayCommand(() => MessageBox.Show("Please input correct value", "Error", MessageBoxButton.OK, MessageBoxImage.Error));
        //        }
        //    }
        //}

        public RelayCommand AddPhrase => new RelayCommand(() =>
        {
            Items.Add(MyText);
            MyText = null;
        });

        public RelayCommand Clear => new RelayCommand(() => Items.Clear());

        private string gtext;

        public RelayCommand Generate => new RelayCommand(() =>
        {
            Random glength = new Random();
            Random Rnd = new Random();
            gtext = null;
            for (int i = 0; i <= glength.Next(0, Items.Count); i++)
            {
                if (i == 0)
                    gtext = Items[Rnd.Next(0, Items.Count)];
                else 
                    gtext += ' '+Items[Rnd.Next(0, Items.Count)];
            }
            GPhrase = gtext;
        });

        public MainViewModel()
        {
            Items = new ObservableCollection<string>();
        }

        private string _gprase;
        public string GPhrase
        {
            get { return _gprase; }
            set
            {
                _gprase = value;
                RaisePropertyChanged(() => GPhrase);
            }
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