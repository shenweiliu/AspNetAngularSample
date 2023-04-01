using System;

namespace AspNet.Angular.Contracts
{
    public class CustomerServiceMessage
    {
        public string Description { get; set; }
        public string Question { get; set; }
        public Guid ProfileId { get; set; }
    }
}
