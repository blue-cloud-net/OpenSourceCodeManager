using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;

using OSCManager.Abstractions.Model.Entities;

namespace OSCManager.Core.Services
{
    public class SourceRepositoryService
    {
        public const string CacheKey = nameof(SourceHub);
        private readonly IMemoryCache _memoryCache;

        public SourceRepositoryService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        private async ValueTask<IDictionary<string, SourceHub>> GetDictionaryAsync(CancellationToken cancellationToken)
        {
            return await _memoryCache.GetOrCreate(CacheKey, async entry =>
            {
                // TODO
                return new Dictionary<string, SourceHub>();
                //entry.Monitor(_cacheSignal.GetToken(CacheKey));
                //return await GetActivityTypesInternalAsync(cancellationToken).ToDictionaryAsync(x => x.TypeName, cancellationToken);
            });
        }
    }
}
