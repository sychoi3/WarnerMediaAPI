using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Domain;
using WarnerMedia.Domain.Entities;

namespace WarnerMedia.Repositories.Interfaces
{
    public interface ICreditRepository
    {
        PagedResult<TitleParticipant> CreditSearch(CreditSearch search);
    }
}
