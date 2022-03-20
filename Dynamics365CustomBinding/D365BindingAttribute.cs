using Microsoft.Azure.WebJobs.Description;

namespace Dynamics365CustomBinding
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class Dynamics365ClientAttribute : Attribute
    {
        [AutoResolve]
        public string ConnectionString { get; set; }

        public Dynamics365ClientAttribute(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
