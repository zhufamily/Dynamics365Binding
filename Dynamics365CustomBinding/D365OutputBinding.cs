using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Xrm.Sdk;


namespace Dynamics365CustomBinding
{
    /// <summary>
    /// Dynamics365Output custom binding extension configuration
    /// </summary>
    [Extension("Dynamics365Output")]
    public class Dynamics365Output : IExtensionConfigProvider
    {
        /// <summary>
        /// Initialize Dynamics365Output custom binding extension configuration
        /// </summary>
        /// <param name="context"></param>
        public void Initialize(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<Dynamics365OutputAttribute>();
            rule.BindToCollector<OrganizationRequest>(attr => new D365OutputAsyncCollector(attr));
        }
    }
}
