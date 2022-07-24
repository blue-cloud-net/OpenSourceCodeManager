using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCManager.Abstractions.Model.Entities
{
    public class Source : BaseEntity
    {
        public string DisplayName { get; set; }
        public string Belong { get; set; }
        public string Name { get; set; }

        public Uri CreateUrl { get; set; }
        public string ConnectType { get; set; }
        public string About { get; set; }
        public string DefaultBranche { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public SourceHub Repository { get; set; }

        public string Url => GetUrl();

        public string GetUrl()
        {
            var dowloadRegistry = Repository.Registries.FirstOrDefault();

            return dowloadRegistry is not null ? new Uri(dowloadRegistry.Url, Belong + "/" + Name).ToString() : string.Empty;
        }
    }
}
