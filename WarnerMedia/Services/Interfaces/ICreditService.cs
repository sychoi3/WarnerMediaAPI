using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Domain;
using WarnerMedia.Domain.Entities;

namespace WarnerMedia.Services.Interfaces
{
    public interface ICreditService
    {
        PagedResult<TitleParticipant> CreditSearch(CreditSearch search);
    }
}
