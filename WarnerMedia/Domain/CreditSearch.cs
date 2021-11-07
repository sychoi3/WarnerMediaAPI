using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Resources.Requests;

namespace WarnerMedia.Domain
{
    public class CreditSearch : SearchBase
    {
        public int? title_id { get; set; }
        public int? participant_id { get; set; }

        public static CreditSearch ToDomain(CreditSearchRequest source)
        {
            if (source == null) return null;
            var dest = new CreditSearch();
            dest.title_id = source.title_id;
            dest.participant_id = source.participant_id;
            dest.search_query = source.search_query;
            dest.ordering = source.ordering;
            dest.page = source.page;
            dest.page_size = Math.Clamp(source.page_size, 1, 100);

            return dest;
        }
    }
}
