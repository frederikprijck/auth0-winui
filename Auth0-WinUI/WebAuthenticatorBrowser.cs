using IdentityModel.Client;
using IdentityModel.OidcClient.Browser;
using System;
using System.Threading.Tasks;
using System.Threading;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Auth0_WinUI
{
    public sealed partial class MainWindow
    {
        public class WebAuthenticatorBrowser : IdentityModel.OidcClient.Browser.IBrowser
        {

            /// <inheritdoc />
            public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
            {
                try
                {
                    WebAuthenticatorResult result = await WebAuthenticator.AuthenticateAsync(
                        new Uri(options.StartUrl),
                        new Uri(options.EndUrl));

                    var url = new RequestUrl(options.EndUrl)
                        .Create(new Parameters(result.Properties));

                    return new BrowserResult
                    {
                        Response = url,
                        ResultType = BrowserResultType.Success
                    };
                }
                catch (TaskCanceledException)
                {
                    return new BrowserResult
                    {
                        ResultType = BrowserResultType.UserCancel,
                        ErrorDescription = "Login canceled by the user."
                    };
                }
            }
        }
    }
}
