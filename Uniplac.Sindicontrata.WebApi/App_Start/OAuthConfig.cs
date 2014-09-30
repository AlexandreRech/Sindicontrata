using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Uniplac.Sindicontrata.WebApi.Providers;
using System;

namespace Uniplac.Sindicontrata.WebApi
{
    public static class OAuthConfig
    {
        public static void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {

                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
                //Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}