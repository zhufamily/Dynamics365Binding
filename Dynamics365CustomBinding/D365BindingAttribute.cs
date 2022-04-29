using Microsoft.Azure.WebJobs.Description;

namespace Dynamics365CustomBinding
{
    /// <summary>
    /// Dynamics365Client annotation attribute
    /// </summary>
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class Dynamics365ClientAttribute : Attribute
    {
        /// <summary>
        /// Dynamics 365 connection string
        /// </summary>
        [AutoResolve]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public Dynamics365ClientAttribute(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
