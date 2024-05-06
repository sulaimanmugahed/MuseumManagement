using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Domain.Common
{
    public abstract class TestBaseEntity<TId> : IEntityId<TId> where TId : notnull
    {
        protected TestBaseEntity()
        {
            
        }
        public TId Id { get; private set; }

        protected TestBaseEntity(TId id)
        {
            if (id is null)
                throw new ArgumentNullException();

            Id = id;
        }
    }

    
}
