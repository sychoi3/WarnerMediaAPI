using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarnerMedia.Resources.Response
{
    public class PagedResponse<T>
    {
        public int count { get; set; }
        public int totalPages { get; set; }
        public int pageSize { get; set; }
        //public string next { get; set; }
        //public string previous { get; set; }
        public IList<T> results { get; set; }

        public PagedResponse() { }
    }

    public static class PaginationHelpers
    {
        public static PagedResponse<T> ToPagedResponse<T>(this IList<T> data, int pageNumber, int pageSize, int totalCount) where T : class
        {
            var totalPages = totalCount > 0 ? ((double)totalCount / (double)pageSize) : 0;
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            //var nextPage = pageNumber < roundedTotalPages
            //    ? uriService.GetPageUri(pageNumber + 1).ToString()
            //    : null;

            //var previousPage = pageNumber - 1 >= 1
            //    ? uriService.GetPageUri(pageNumber - 1).ToString()
            //    : null;

            return new PagedResponse<T>
            {
                results = data,
                count = totalCount,
                //next = nextPage,
                //previous = previousPage,
                pageSize = data.Count,
                totalPages = roundedTotalPages
            };
        }
    }
}
