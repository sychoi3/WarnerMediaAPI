using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Domain.Entities;

namespace WarnerMedia.Resources
{
    public class TitleDetailResource
    {
        public int title_id { get; set; }
        public string title_name { get; set; }
        public int? release_year { get; set; }

        public string story_line { get; set; }
        //public IList<StoryLineResource> story_lines { get; set; }
        public IList<AwardResource> awards { get; set; }
        public IList<GenreResource> genres { get; set; }

        public static TitleDetailResource ToResource(Title source)
        {
            if (source == null) return null;

            var dest = new TitleDetailResource();
            dest.title_id = source.TitleId;
            dest.title_name = source.TitleName;
            dest.release_year = source.ReleaseYear;
            dest.story_line = source.StoryLines.FirstOrDefault(x => x.Type == "Turner External").Description;
            //dest.story_lines = StoryLineResource.ToResource(source.StoryLines);
            dest.awards = AwardResource.ToResource(source.Awards);
            dest.genres = GenreResource.ToResource(source.TitleGenres);
            return dest;
        }
        public IList<TitleDetailResource> ToResource(ICollection<Title> source) => source.Select(x => ToResource(x)).ToList();
    }
}
