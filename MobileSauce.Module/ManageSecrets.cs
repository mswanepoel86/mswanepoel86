using Microsoft.Extensions.Configuration;

namespace MobileSauce.Module
{
    public class ManageSecrets
    {

        public static IConfigurationBuilder Builder = new ConfigurationBuilder().AddUserSecrets<ManageSecrets>();
        public static IConfiguration Configuration => Builder.Build();

        public string GetSecret(string keyValueToLookUp)
        {
            return Configuration[keyValueToLookUp];
        }

    }
}
