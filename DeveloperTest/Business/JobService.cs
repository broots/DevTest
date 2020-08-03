using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            return context.Jobs.Include(x => x.Customer).Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                CustomerId = x.Customer != null ? (int?)x.Customer.Id : null,
                CustomerName = x.Customer != null ? x.Customer.Name : null,
                CustomerType = x.Customer != null ? x.Customer.Type : null,
            }).ToArray();
        }

        public JobModel GetJob(int jobId)
        {
            return context.Jobs.Where(x => x.JobId == jobId)
                .Include(x => x.Customer)
                .Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                CustomerId = x.Customer != null ? (int?)x.Customer.Id : null,
                CustomerName = x.Customer != null ? x.Customer.Name : null,
                CustomerType = x.Customer != null ? x.Customer.Type : null,
                }).SingleOrDefault();
        }

        public JobModel CreateJob(JobModel model)
        {
            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                CustomerId = model.CustomerId,
            });

            context.SaveChanges();

            return new JobModel
            {
                JobId = addedJob.Entity.JobId,
                Engineer = addedJob.Entity.Engineer,
                When = addedJob.Entity.When,
                CustomerId = addedJob.Entity.CustomerId,
                CustomerName = model.CustomerName
            };
        }
    }
}
