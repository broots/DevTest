using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Database.Models.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime? DateCreated { get; set; }
        DateTime? DateModified { get; set; }
    }
}
