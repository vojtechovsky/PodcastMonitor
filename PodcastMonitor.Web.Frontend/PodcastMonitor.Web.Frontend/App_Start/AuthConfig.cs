using System.Configuration;
using Microsoft.Web.WebPages.OAuth;

namespace PodcastMonitor.Web.Frontend
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            var twitterConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            var twitterConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            OAuthWebSecurity.RegisterTwitterClient(twitterConsumerKey,twitterConsumerSecret);

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "507083616018201",
                appSecret: "60c8787ef12e64503177a7ff70791963");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
