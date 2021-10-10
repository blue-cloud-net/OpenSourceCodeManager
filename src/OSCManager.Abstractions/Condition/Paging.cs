
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OSCManager.Abstractions.Condition
{
    public class Paging
    {
        public static Paging Page(int page, int pageSize) => new(page * pageSize, pageSize);

        public Paging(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get; }
        public int Take { get; }
    }
}
