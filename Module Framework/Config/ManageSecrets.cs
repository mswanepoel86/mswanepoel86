using Microsoft.Extensions.Configuration;

namespace Module_Framework.Config
{
    public class ManageSecrets
    {

        public  IConfigurationBuilder Builder = new ConfigurationBuilder().AddUserSecrets<ManageSecrets>();
        public  IConfiguration Configuration => Builder.Build();

        public string GetSecret(string keyValueToLookUp)
        {
            return Configuration[keyValueToLookUp];
        }

    }
}
