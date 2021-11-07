using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Resources.Requests;

namespace WarnerMedia.Domain
{
    public class TitleSearch : SearchBase
    {
        public static TitleSearch ToDomain(TitleSearchRequest source)
        {
            if (source == null) return null;
            var dest = new TitleSearch();
            dest.search_query = source.search_query;
            dest.ordering = source.ordering;
            dest.page = source.page;
            dest.page_size = Math.Clamp(source.page_size, 1, 100);

            return dest;
        }
    }
}
