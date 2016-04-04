using System.Configuration;
using System.IO;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShipmentsAPI
{
    public partial class Startup
    {
        private JObject _authZeroInfo = null;

        private JObject AuthZeroInfo
        {
            get
            {
                if (_authZeroInfo == null)
                {
                    string folder = ConfigurationManager.AppSettings["auth0FileFolder"];
                    _authZeroInfo = JObject.Parse(File.ReadAllText(Path.Combine(folder, ".auth0.json")));
                }
                return _authZeroInfo;
            }
        }

        private string Domain
        {
            get
            {
                JToken domain = null;
                AuthZeroInfo.TryGetValue("Domain", out domain);
                return (string)domain;
            }
        }

        private string ClientID
        {
            get
            {
                JToken id = null;
                AuthZeroInfo.TryGetValue("ClientID", out id);
                return (string)id;
            }
        }

        private string ClientSecret
        {
            get
            {
                JToken secret = null;
                AuthZeroInfo.TryGetValue("ClientSecret", out secret);
                return (string)secret;
            }
        }

        private void ConfigurationAuthZero(IAppBuilder app)
        {
            var issuer = "https://" + Domain + "/";
            var audience = ClientID;
            var secret = TextEncodings.Base64.Encode(
                TextEncodings.Base64Url.Decode(ClientSecret));

            app.UseJwtBearerAuthentication(new Microsoft.Owin.Security.Jwt.JwtBearerAuthenticationOptions
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                AllowedAudiences = new[] { audience },
                IssuerSecurityTokenProviders = new[]
                {
                    new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret),
                }
            });
        }
        
    }
}