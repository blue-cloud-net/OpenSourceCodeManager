using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCManager.Abstractions.Options
{
    public class DatabaseOptions
    {
        public string Type { get; set; }

        [Required]
        public string ConnectionString { get; set; }
    }
}
