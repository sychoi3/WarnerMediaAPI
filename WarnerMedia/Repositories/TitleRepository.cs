using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Domain;
using WarnerMedia.Domain.Entities;
using WarnerMedia.Repositories.Interfaces;

namespace WarnerMedia.Repositories
{
    public class TitleRepository : ITitleRepository
    {
        private readonly TitlesContext _context;
        public TitleRepository(TitlesContext context)
        {
            _context = context;
        }

        public PagedResult<Title> TitleSearch(TitleSearch search)
        {
            var query = TitleQuery();

            if (!string.IsNullOrWhiteSpace(search.search_query))
            {
                var searchQuery = search.search_query;
                query = query.Where(x => x.OtherNames.Any(a => a.TitleName.Contains(searchQuery)));
            }

            var dsc = search.ordering?.StartsWith("-") ?? false;
            var ordering = dsc ? search.ordering.Remove(0, 1) : search.ordering;
            switch (ordering)
            {
                case "id":
                    query = dsc ? query.OrderByDescending(x => x.TitleId) : query.OrderBy(x => x.TitleId);
                    break;
                case "name":
                    query = dsc ? query.OrderByDescending(x => x.TitleNameSortable) : query.OrderBy(x => x.TitleNameSortable);
                    break;
                case "year":
                    query = dsc ? query.OrderByDescending(x => x.ReleaseYear) : query.OrderBy(x => x.ReleaseYear);
                    break;
                default:
                    query = query.OrderBy(x => x.TitleId);
                    break;
            }

            var page = query.GetPaged(search.page, search.page_size);
            return page;
        }

        public Title GetById(int id)
        {
            var query = TitleQuery();
            return query.FirstOrDefault(x => x.TitleId == id);
        }

        public IQueryable<Title> TitleQuery(bool tracking = false)
        {
            var query = _context.Titles
                .Include(x => x.OtherNames)
                .Include(x => x.StoryLines)
                .Include(x => x.TitleGenres)
                    .ThenInclude(x => x.Genre)
                .Include(x => x.Awards)
                .AsQueryable();

            if (!tracking)
                query.AsNoTracking();

            return query;
        }
    }
}
