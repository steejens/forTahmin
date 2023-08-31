using System;
using Application.Enums;

namespace Application.Configurations
{
    public interface IEntity
    {
        StatusEnum Status { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateModified { get; set; }
        DateTime? DateDeleted { get; set; }

    }
}
