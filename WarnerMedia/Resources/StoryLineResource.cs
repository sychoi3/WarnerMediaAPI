using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Domain.Entities;

namespace WarnerMedia.Resources
{
    public class StoryLineResource
    {
        public string type { get; set; }
        public string language { get; set; }
        public string description { get; set; }

        public static StoryLineResource ToResource(StoryLine source)
        {
            if (source == null) return null;

            var dest = new StoryLineResource();
            dest.type = source.Type;
            dest.language = source.Language;
            dest.description = source.Description;
            return dest;
        }
        public static IList<StoryLineResource> ToResource(ICollection<StoryLine> source) => source.Select(x => ToResource(x)).ToList();
    }
}
