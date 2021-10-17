using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCManager.Persistence.Core.Entities
{
    public class SourceRepositoryRegistry : BaseEntity
    {
        public string Domain { get; set; }
        public string Description { get; set; }
        public Uri Url { get; set; }
        public bool IsMainRegistry { get; set; } = false;
        public bool IsUseRegistry { get; set; } = false;

        public string UrlString => Url.ToString();
    }
}
