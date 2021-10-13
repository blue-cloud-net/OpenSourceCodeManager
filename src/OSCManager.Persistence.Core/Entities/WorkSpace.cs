using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCManager.Persistence.Core.Entities
{
    public class WorkSpace : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
