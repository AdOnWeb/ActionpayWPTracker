using Actionpay.Tracker.WP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace TrackerExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
      int startCount = 0;
      int endCount = 0;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            SLTracker.SharedTracker.BeginSend += (sender, action) =>
            {
              startCount++;
              Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
              {
                Status.Text = startCount + " / " + endCount;
              }).AsTask().Wait();
              return true;
            };
            SLTracker.SharedTracker.EndSend += (sender, action) =>
            {
              endCount++;
              Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
              {
                Status.Text = startCount + " / " + endCount;
              }).AsTask().Wait();
              System.Diagnostics.Debug.WriteLine(action.Name + " : " + action.Sent);
            };
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          SLTracker.SharedTracker.TrackAction("event");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          SLTracker.SharedTracker.TrackAction("purchase", "100");
        }
    }
}
