using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Domain;
using WarnerMedia.Domain.Entities;
using WarnerMedia.Repositories.Interfaces;
using WarnerMedia.Services.Interfaces;

namespace WarnerMedia.Services
{
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository _titleRepository;
        public TitleService(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public PagedResult<Title> TitleSearch(TitleSearch search)
        {
            return _titleRepository.TitleSearch(search);
        }

        public Title GetTitleById(int titleId)
        {
            var title = _titleRepository.GetById(titleId);
            return title;
        }
    }
}
