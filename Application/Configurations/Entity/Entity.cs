


using Application.Enums;

namespace Application.Configurations
{
    public class Entity : IEntity
    {
        public StatusEnum Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }


        public Entity()
        {
            Status = StatusEnum.Active;
        }
    }
}
