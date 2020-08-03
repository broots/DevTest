using System;

namespace DeveloperTest.Models
{
    public class JobModel : BaseJobModel
    {
        public int JobId { get; set; }

        public int? CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerType { get; set; }
    }
}
