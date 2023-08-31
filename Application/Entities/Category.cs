using System.Collections.ObjectModel;
using Application.Configurations;
using Application.Enums;

namespace Application.Entities
{
    public class Category: IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Product> Products { get; set; } = new Collection<Product>();
        public StatusEnum Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
