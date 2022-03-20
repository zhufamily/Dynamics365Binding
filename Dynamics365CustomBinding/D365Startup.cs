using Dynamics365CustomBinding;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: WebJobsStartup(typeof(D365Startup))]
namespace Dynamics365CustomBinding
{
    /// <summary>
    /// Custom binding Web Job initializer
    /// </summary>
    public class D365Startup : IWebJobsStartup
    {
        /// <summary>
        /// Add custom binding extensions to Web Job
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Configure(IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<Dynamics365Client>();
            builder.AddExtension<Dynamics365Output>();            
        }
    }
}
