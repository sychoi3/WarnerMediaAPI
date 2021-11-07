using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Domain.Entities;

namespace WarnerMedia.Resources
{
    public class GenreResource
    {
        public int id { get; set; }
        public string name { get; set; }
        public static GenreResource ToResource(TitleGenre source)
        {
            if (source == null) return null;

            var dest = new GenreResource();
            dest.id = source.GenreId;
            dest.name = source.Genre.Name;
            return dest;
        }

        public static IList<GenreResource> ToResource(ICollection<TitleGenre> source) => source.Select(x => ToResource(x)).ToList();
    }
}
