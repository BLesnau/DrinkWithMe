using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
        }

        private async void Button_Click( object sender, Windows.UI.Xaml.RoutedEventArgs e )
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
           catch ( Exception ex )
           {
              var m = new MessageDialog( ex.Message, "Exception" );
              m.ShowAsync();
           }
        }
    }
}
