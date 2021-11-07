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
    public class CreditService : ICreditService
    {
        private readonly ICreditRepository _creditRepository;
        public CreditService(ICreditRepository creditRepository)
        {
            _creditRepository = creditRepository;
        }

        public PagedResult<TitleParticipant> CreditSearch(CreditSearch search)
        {
            return _creditRepository.CreditSearch(search);
        }
    }
}
