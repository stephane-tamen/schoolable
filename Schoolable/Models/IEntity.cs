using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolable.Models
{
    public interface IEntity
    {
        DateTime Created { get; set; }
        DateTime LastModified { get; set; }
    }
}
