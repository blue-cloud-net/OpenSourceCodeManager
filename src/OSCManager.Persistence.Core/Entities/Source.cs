using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCManager.Persistence.Core.Entities
{
    public class Source : BaseEntity
    {
        public string DisplayName { get; set; }
        public string Belong { get; set; }
        public string Name { get; set; }

        public Uri CreateUrl { get; set; }
        public string About { get; set; }
        public string DefaultBranche { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public SourceRepositoryRegistry Registry { get; set; }

        public string Url => new Uri(Registry.Url, Belong + "/" + Name).ToString();
    }
}
