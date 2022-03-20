using Microsoft.Azure.WebJobs;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;

namespace Dynamics365CustomBinding
{
    /// <summary>
    /// Dyanmics365Output custom binding implementation 
    /// </summary>
    public class D365OutputAsyncCollector : IAsyncCollector<OrganizationRequest>
    {
        /// <summary>
        /// Dynamics 365 attribute
        /// </summary>
        readonly Dynamics365OutputAttribute attr;
        /// <summary>
        /// Multiple command request
        /// </summary>
        private ExecuteMultipleRequest requestWithResults;

        /// <summary>
        /// Constructor from Dynamics 365 attribute -- read from annotation
        /// </summary>
        /// <param name="attr"></param>
        public D365OutputAsyncCollector(Dynamics365OutputAttribute attr)
        {
            this.attr = attr;
            requestWithResults = new ExecuteMultipleRequest()
            {
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = attr.ContinueOnError,
                    ReturnResponses = false
                }
            };
            if (requestWithResults.Requests == null)
            {
                requestWithResults.Requests = new OrganizationRequestCollection();
            }
        }

        /// <summary>
        /// Add a command to multiple execution commands
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task AddAsync(OrganizationRequest item, CancellationToken cancellationToken = default(CancellationToken))
        {
            requestWithResults.Requests.Add(item);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Execute all commands
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(attr.Connection))
                throw new ArgumentException("Missing required parameter ConnectionString");

            try
            {
                if (requestWithResults.Requests.Count() > 0)
                {
                    using (ServiceClient client = new ServiceClient(attr.Connection))
                    {
                        client.Execute(requestWithResults);
                    }
                    requestWithResults.Requests.Clear();
                }
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
