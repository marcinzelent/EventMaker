using Windows.UI.Core;

namespace EventMaker.View
{
    public sealed partial class CreateEventPage
    {
        SystemNavigationManager currentView = SystemNavigationManager.GetForCurrentView();
        public CreateEventPage()
        {
            InitializeComponent();
            currentView.BackRequested += OnBackRequested;
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
                currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }

        private void GoToEventPage(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EventPage));
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }
    }
}
