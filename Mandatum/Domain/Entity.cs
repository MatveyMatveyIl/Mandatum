using System;

namespace Domain
{
    public class Entity<TId>
    {
        public TId Id;

        public Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}