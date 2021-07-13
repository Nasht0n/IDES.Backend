using System;

namespace Domain.Models
{
    public abstract class BaseObject
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
