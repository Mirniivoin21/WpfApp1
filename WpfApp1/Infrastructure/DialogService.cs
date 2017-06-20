using System;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfApp1.Infrastructure
{
    //TODO: afterHideCallback not implemented. IMHO MatApps message should be overrided with callback!
    public class DialogService : IDialogService
    {
        public async Task ShowError(string message, string title, string buttonText, Action afterHideCallback) =>
            await ((MetroWindow) Application.Current.MainWindow).ShowMessageAsync(title, message, 
                MessageDialogStyle.Affirmative,new MetroDialogSettings {AffirmativeButtonText = buttonText});

        public async Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback) =>
            await((MetroWindow) Application.Current.MainWindow).ShowMessageAsync(title, error.Message,
                MessageDialogStyle.Affirmative, new MetroDialogSettings {AffirmativeButtonText = buttonText});

        public async Task ShowMessage(string message, string title) =>
            await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync(title, message);

        public async Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback) =>
            await((MetroWindow) Application.Current.MainWindow).ShowMessageAsync(title, message,
                MessageDialogStyle.Affirmative, new MetroDialogSettings {AffirmativeButtonText = buttonText});

        public async Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText,
            Action<bool> afterHideCallback)
        {
            await ((MetroWindow) Application.Current.MainWindow).ShowMessageAsync(title, message,
                MessageDialogStyle.AffirmativeAndNegative,
                new MetroDialogSettings
                {
                    AffirmativeButtonText = buttonConfirmText,
                    NegativeButtonText = buttonCancelText
                });
            return false;
        }

        public Task ShowMessageBox(string message, string title)
        {
            throw new NotImplementedException();
        }
    }
}
