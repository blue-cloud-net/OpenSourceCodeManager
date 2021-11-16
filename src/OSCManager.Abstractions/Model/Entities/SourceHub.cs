using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCManager.Abstractions.Model.Entities
{
    public class SourceHub : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<SourceHubRegistry> Registries { get; set; }
    }
}
