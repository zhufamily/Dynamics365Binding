using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.PowerPlatform.Dataverse.Client;

namespace Dynamics365CustomBinding
{
    /// <summary>
    /// Dynamics365Client custom binding extension configuration
    /// </summary>
    [Extension("Dynamics365Client")]
    public class Dynamics365Client : IExtensionConfigProvider
    {
        /// <summary>
        /// Initialize Dynamics365Client custom binding extension configuration
        /// </summary>
        /// <param name="context"></param>
        public void Initialize(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<Dynamics365ClientAttribute>();
            rule.BindToInput<ServiceClient>(BuildItemFromAttribute);
        }

        /// <summary>
        /// Generate Service Client for binding
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private ServiceClient BuildItemFromAttribute(Dynamics365ClientAttribute arg)
        {
            if (string.IsNullOrEmpty(arg.ConnectionString))
                throw new ArgumentException("Missing required parameter ConnectionString");

            try
            {
                ServiceClient client = new ServiceClient(arg.ConnectionString);
                return client;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
