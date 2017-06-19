using System;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfApp1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        public RelayCommand AddPhrase => new RelayCommand(AddPhraseCommand);

        public RelayCommand Remove => new RelayCommand(RemoveCommand);

        public RelayCommand Clear => new RelayCommand(() => Items.Clear());

        public RelayCommand Generate => new RelayCommand(GenerateCommand);

        public RelayCommand ShowInfoCommand => new RelayCommand(() => ShowInfo = true);

        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            Items = new ObservableCollection<string>();
        }

        private void AddPhraseCommand()
        {
            if (!string.IsNullOrEmpty(MyText))
            {
                Items.Add(MyText);
                MyText = String.Empty;
            }
            else
            {
                _dialogService.ShowMessage("Please input any value!", "Incorrect value!");
            }
        }

        private void RemoveCommand()
        {
            if (!string.IsNullOrEmpty(SelectItem))
                Items.Remove(SelectItem);
            else
                _dialogService.ShowMessage("Please select any item!", "Nothing to do!");
        }

        private void GenerateCommand()
        {
            if (Items.Count != 0)
            {
                var glength = new Random();
                var rnd = new Random();
                string gtext = null;
                for (var i = 0; i <= glength.Next(0, Items.Count); i++)
                {
                    if (i == 0)
                        gtext = Items[rnd.Next(0, Items.Count)];
                    else
                        gtext += ' ' + Items[rnd.Next(0, Items.Count)];
                }
                GPhrase = gtext;
            }
            else
            {
                _dialogService.ShowMessage("List cannot be empty! Add some data.", "Nothing to do!");
            }
        }

        public string SelectItem { get; set; }

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

        private bool _showInfo;
        public bool ShowInfo
        {
            get => _showInfo;
            set => Set(() => ShowInfo, ref _showInfo, value);
        }
    }
}