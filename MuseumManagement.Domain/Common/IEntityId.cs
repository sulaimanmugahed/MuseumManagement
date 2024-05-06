using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Domain.Common
{
    public interface IEntityId<TId> where TId : notnull 
    {
        TId Id { get; }
    }
}
