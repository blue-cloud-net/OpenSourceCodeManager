using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSCManager.Abstractions;

namespace OSCManager.Persistence.Core.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public string Id { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime? DeleteTime { get; set; }
    }
}
