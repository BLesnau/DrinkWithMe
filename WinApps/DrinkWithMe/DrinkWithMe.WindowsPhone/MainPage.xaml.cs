using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Microsoft.WindowsAzure.MobileServices;

namespace DrinkWithMe
{
   /// <summary>
   /// An empty page that can be used on its own or navigated to within a Frame.
   /// </summary>
   public sealed partial class MainPage : Page
   {
      public MainPage()
      {
         this.InitializeComponent();

         this.NavigationCacheMode = NavigationCacheMode.Required;
      }

      /// <summary>
      /// Invoked when this page is about to be displayed in a Frame.
      /// </summary>
      /// <param name="e">Event data that describes how this page was reached.
      /// This parameter is typically used to configure the page.</param>
      protected override void OnNavigatedTo( NavigationEventArgs e )
      {
         // TODO: Prepare page for display here.

         // TODO: If your application contains multiple pages, ensure that you are
         // handling the hardware Back button by registering for the
         // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
         // If you are using the NavigationHelper provided by some templates,
         // this event is handled for you.
      }

      private async void Button_Click( object sender, RoutedEventArgs e )
      {
         try
         {
            var app = Application.Current as App;
            if ( app != null )
            {
               if ( app.MobileService != null )
               {
                  var login = await app.MobileService.LoginAsync( MobileServiceAuthenticationProvider.Google );
                  var m = new MessageDialog( String.Format( "{0} {1}", login.UserId, login.MobileServiceAuthenticationToken ), "Title" );
                  await m.ShowAsync();
               }
            }
         }
         catch ( Exception ex)
         {
            var m = new MessageDialog(ex.Message,"Exception");
            m.ShowAsync();
         }
      }
   }
}