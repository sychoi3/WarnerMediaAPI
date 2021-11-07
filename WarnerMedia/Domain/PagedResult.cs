using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarnerMedia.Domain
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int FirstRowOnPage
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, TotalCount); }
        }
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }
        public PagedResult()
        {
            Results = new List<T>();
        }
    }

    public static class PageHelper
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            page = page < 1 ? 1 : page; // bottom out at page 1.
            var totalCount = query.Count();
            var pageCount = (double)totalCount / pageSize;
            var totalPages = (int)Math.Ceiling(pageCount);

            var result = new PagedResult<T>();
            if (totalCount == 0) return result;

            page = page > totalPages ? totalPages : page;   // top out at page N.

            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.TotalCount = totalCount;
            result.PageCount = totalPages;

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}
