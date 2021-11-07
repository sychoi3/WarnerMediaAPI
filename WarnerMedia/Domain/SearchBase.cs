using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarnerMedia.Domain
{
    public class SearchBase
    {
        public string search_query { get; set; }

        /// <summary>
        /// [-] field
        /// </summary>
        public string ordering { get; set; }
        public int page { get; set; }
        public int page_size { get; set; }
    }
}
