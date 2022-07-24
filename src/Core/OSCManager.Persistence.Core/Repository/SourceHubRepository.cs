using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using OSCManager.Abstractions.Model.Entities;
using OSCManager.Abstractions.Persistence;

namespace OSCManager.Persistence.Core.Repository
{
    public class SourceHubRepository : BaseRepository<SourceHub>, ISourceHubRepository
    {
        public SourceHubRepository(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
