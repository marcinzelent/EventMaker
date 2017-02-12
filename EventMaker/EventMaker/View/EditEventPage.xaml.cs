using Windows.UI.Core;
using Windows.UI.Xaml;

namespace EventMaker.View
{
    public sealed partial class EditEventPage
    {
        SystemNavigationManager currentView = SystemNavigationManager.GetForCurrentView();
        public EditEventPage()
        {
            InitializeComponent();
            currentView.BackRequested += OnBackRequested;
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame.Navigate(typeof(EventPage));
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void GoToEventPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EventPage));
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }
    }
}
