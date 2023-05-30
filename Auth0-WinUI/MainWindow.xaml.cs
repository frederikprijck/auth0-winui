using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Auth0_WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        Auth0Client client;

        public MainWindow()
        {
            this.InitializeComponent();

            client = new Auth0Client(new IdentityModel.OidcClient.OidcClientOptions()
            {
                Authority = "https://{AUTH0_DOMAIN}",
                ClientId = "{AUTH0_CLIENT_ID}",
                Browser = new WebAuthenticatorBrowser(),
                RedirectUri = "myapp://callback",
                Scope = "openid profile email",
            });

        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
            var result = await client.LogInAsync();

            myButton.Content = result.IdentityToken;
        }
    }
}
