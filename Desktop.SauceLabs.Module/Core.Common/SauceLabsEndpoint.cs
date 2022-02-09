using System;

namespace Desktop.SauceLabs.Module.Core.Common
{
    public class SauceLabsEndpoint
    {
        public string SauceUsWestDomain { get; set; }
        public string SauceHubUrl { get; set; }
        public Uri SauceHubUri { get; set; }
        public static Uri UsWestHubUri { get; set; }
        public static string HeadlessRestApiUrl { get; set; }

        public Uri EmusimUri(string sauceUser, string sauceKey)
        {
            return new($"https://{sauceUser}:{sauceKey}{SauceUsWestDomain}");
        }
    }
}
