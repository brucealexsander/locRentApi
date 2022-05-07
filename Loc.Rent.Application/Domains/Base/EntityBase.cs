namespace Loc.Rent.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public EntityBase()
        {

        }
        public EntityBase(int id)
        {
            Id = id;
        }

        public virtual int Id { get; protected set; }
    }
}
