using System.Windows;
using MahApps.Metro.Controls;

namespace WpfApp1.View
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private MetroWindow accentThemeTestWindow;

        private void ChangeAppStyleButtonClick(object sender, RoutedEventArgs e)
        {
            if (accentThemeTestWindow != null)
            {
                accentThemeTestWindow.Activate();
                return;
            }

            accentThemeTestWindow = new AccentStyleWindow();
            accentThemeTestWindow.Owner = this;
            accentThemeTestWindow.Closed += (o, args) => accentThemeTestWindow = null;
            accentThemeTestWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            accentThemeTestWindow.ShowMinButton = false;
            accentThemeTestWindow.ShowMaxRestoreButton = false;
            accentThemeTestWindow.Show();
        }
    }
}
