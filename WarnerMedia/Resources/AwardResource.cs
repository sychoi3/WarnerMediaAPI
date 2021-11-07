using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Domain.Entities;

namespace WarnerMedia.Resources
{
    public class AwardResource
    {
        public bool award_won { get; set; }
        public int? award_year { get; set; }
        public string award_name { get; set; }
        public string award_company { get; set; }

        public static AwardResource ToResource(Award source)
        {
            if (source == null) return null;

            var dest = new AwardResource();
            dest.award_won = source.AwardWon ?? false;
            dest.award_year = source.AwardYear;
            dest.award_name = source.Award1;
            dest.award_company = source.AwardCompany;
            return dest;
        }

        public static IList<AwardResource> ToResource(ICollection<Award> source) => source.Select(x => ToResource(x)).ToList();
    }
}
