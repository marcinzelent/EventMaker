using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EventMaker.View
{
    public sealed partial class EventPage
    {
        public EventPage()
        {
            InitializeComponent();
        }

        private void SelectEvent(object sender, RoutedEventArgs e)
        {
            var item = ((Grid)((Button)sender).Parent).DataContext;
            var container = (ListViewItem)EventsList.ContainerFromItem(item);

            container.IsSelected = true;
        }
    }
}
