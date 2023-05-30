# Auth0-WinUI
Example application to demonstrate how to integrate Auth0 in a [.NET WinUI application](https://learn.microsoft.com/en-us/windows/apps/winui/winui3/create-your-first-winui3-app), using [`IdentityModel.OidcClient`](https://www.nuget.org/packages/IdentityModel.OidcClient).

## Configuring Auth0

Ensure to create or use an existing Native application on Auth0, with the following things configured:

- **Allowed Callback URLs**: `myapp://callback`
- **Allowed Logout URLs**: `myapp://callback`

## Configuring the application

Provide the correct values for both the `Authority` and the `ClientId` in `MainWindow.xaml.cs`.

- **Authority**: Replace with your auth0 domain, including `https://` (e.g. `https://your-company.us.auth0.com`)
- **ClientId**: Replace with the client id of the native application in Auth0.