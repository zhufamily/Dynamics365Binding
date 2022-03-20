using Microsoft.Azure.WebJobs.Description;

namespace Dynamics365CustomBinding
{
    /// <summary>
    /// Dynamics365Output annotation attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    [Binding]
    public sealed class Dynamics365OutputAttribute : Attribute
    {
        /// <summary>
        /// Dynamics 365 connection string
        /// </summary>
        [AutoResolve]
        public string Connection { get; set; }
        /// <summary>
        /// Continue execution for errors
        /// </summary>
        public bool ContinueOnError { get; set; }

        /// <summary>
        /// Constructor set ContinueOnError to false as default
        /// </summary>
        /// <param name="connection"></param>
        public Dynamics365OutputAttribute(string connection)
        {
            Connection = connection;
            ContinueOnError = false;
        }
    }
}
