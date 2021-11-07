using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Domain.Entities;

namespace WarnerMedia.Resources
{
    public class TitleResource
    {
        public int title_id { get; set; }
        public string title_name { get; set; }
        public int? release_year { get; set; }
        public static TitleResource ToResource(Title source)
        {
            if (source == null) return null;
            var dest = new TitleResource();
            dest.title_id = source.TitleId;
            dest.title_name = source.TitleName;
            dest.release_year = source.ReleaseYear;

            return dest;
        }

        public static IList<TitleResource> ToResource(ICollection<Title> source) => source.Select(x => ToResource(x)).ToList();
    }
}
