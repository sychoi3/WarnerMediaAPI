using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Domain;
using WarnerMedia.Domain.Entities;

namespace WarnerMedia.Repositories.Interfaces
{
    public interface ITitleRepository
    {
        PagedResult<Title> TitleSearch(TitleSearch search);
        Title GetById(int id);
    }
}
