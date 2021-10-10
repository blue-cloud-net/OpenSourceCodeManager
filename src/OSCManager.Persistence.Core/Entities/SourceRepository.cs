using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCManager.Persistence.Core.Entities
{
    public class SourceRepository : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<SourceRepositoryRegistry> Registries { get; set; }
    }
}
