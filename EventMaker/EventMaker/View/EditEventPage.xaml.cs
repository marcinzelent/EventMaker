using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace EventMaker.View
{
    public sealed partial class EditEventPage
    {
        private readonly SystemNavigationManager _currentView = SystemNavigationManager.GetForCurrentView();

        public EditEventPage()
        {
            InitializeComponent();
            _currentView.BackRequested += OnBackRequested;
            _currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame.Navigate(typeof(EventPage));
            _currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void GoToEventPage(object sender, RoutedEventArgs e)
        {
            var allFilled = true;
            foreach (var control in EventForm.Children)
                if (control is TextBox && string.IsNullOrWhiteSpace(((TextBox) control).Text))
                {
                    ((TextBox) control).BorderBrush = new SolidColorBrush(Colors.Red);
                    allFilled = false;
                }
                else if (control is TextBox)
                {
                    ((TextBox) control).BorderBrush = new SolidColorBrush(Color.FromArgb(255, 122, 122, 122));
                }
            if (allFilled)
            {
                Frame.Navigate(typeof(EventPage));
                _currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }
    }
}