using System;

namespace MuseumManagement.Domain.Common
{
    public abstract class Entity
    {

        public Entity()
        {
            
        }
        protected Entity(string id)
        {
            Id = id;
        }
        public string Id { get; private init; }


     
    }
}
