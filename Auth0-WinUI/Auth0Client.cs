using IdentityModel.Client;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth0_WinUI
{
    internal class Auth0Client
    {
        private readonly OidcClient oidcClient;

        public Auth0Client(OidcClientOptions oidcClientOptions)
        {
            oidcClient = new OidcClient(oidcClientOptions);
        }

        public Task<LoginResult> LogInAsync()
        {
            return oidcClient.LoginAsync();
        }

        public async Task LogOut()
        {
            var logoutParameters = new Dictionary<string, string>
            {
              {"client_id", oidcClient.Options.ClientId },
              {"returnTo", oidcClient.Options.RedirectUri }
            };

            var logoutRequest = new LogoutRequest();
            var endSessionUrl = new RequestUrl($"{oidcClient.Options.Authority}/v2/logout")
              .Create(new Parameters(logoutParameters));
            var browserOptions = new BrowserOptions(endSessionUrl, oidcClient.Options.RedirectUri)
            {
                Timeout = TimeSpan.FromSeconds(logoutRequest.BrowserTimeout),
                DisplayMode = logoutRequest.BrowserDisplayMode
            };

            await oidcClient.Options.Browser.InvokeAsync(browserOptions);
        }
    }
}