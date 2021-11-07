using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarnerMedia.Resources.Requests
{
    public class CreditSearchRequest : SearchRequest
    {
        public int? title_id { get; set; }
        public int? participant_id { get; set; }
    }
}
