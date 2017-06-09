using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBM.Core
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public Status Status { get; set; }

        public Entity()
        {
            this.Id = Guid.NewGuid();
            this.CreationDate = DateTime.Now;
            this.ModificationDate = DateTime.Now;
            this.Status = Status.Active;
        }
    }

    public enum Status
    {
        Deleted = 0,
        Active = 5
    }
}
