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
    public class CreditRepository : ICreditRepository
    {
        private readonly TitlesContext _context;
        public CreditRepository(TitlesContext context)
        {
            _context = context;
        }

        public PagedResult<TitleParticipant> CreditSearch(CreditSearch search)
        {
            var query = TitleParticipantQuery();

            //if (!string.IsNullOrWhiteSpace(search.search_query))
            //{
            //    var searchQuery = search.search_query;
            //    query = query.Where(x => x.OtherNames.Any(a => a.TitleName.Contains(searchQuery)));
            //}

            if (search.title_id.HasValue)
            {
                var titleId = search.title_id.Value;
                query = query.Where(x => x.TitleId == titleId);
            }

            if (search.participant_id.HasValue)
            {
                var participantId = search.participant_id.Value;
                query = query.Where(x => x.ParticipantId == participantId);
            }

            var dsc = search.ordering?.StartsWith("-") ?? false;
            var ordering = dsc ? search.ordering.Remove(0, 1) : search.ordering;
            switch (ordering)
            {
                case "id":
                    query = dsc ? query.OrderByDescending(x => x.ParticipantId) : query.OrderBy(x => x.Participant);
                    break;
                case "name":
                    query = dsc ? query.OrderByDescending(x => x.Participant.Name) : query.OrderBy(x => x.Participant.Name);
                    break;
                default:
                    query = query.OrderBy(x => x.ParticipantId);
                    break;
            }

            var page = query.GetPaged(search.page, 100);
            return page;
        }

        public IQueryable<TitleParticipant> TitleParticipantQuery(bool tracking = false)
        {
            var query = _context.TitleParticipants
                .Include(x => x.Participant)
                .Include(x => x.Title)
                .AsQueryable();

            if (!tracking)
                query.AsNoTracking();

            return query;
        }
    }
}
