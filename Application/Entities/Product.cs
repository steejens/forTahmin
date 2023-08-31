using Application.Configurations;
using Application.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Entities
{
    public class Product: IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        [ForeignKey(nameof(Category))]
        public Guid CatId { get; set; }
        public Category Category { get; set; }

        public StatusEnum Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
