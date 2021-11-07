using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Domain;
using WarnerMedia.Resources;
using WarnerMedia.Resources.Requests;
using WarnerMedia.Resources.Response;
using WarnerMedia.Services;
using WarnerMedia.Services.Interfaces;

namespace WarnerMedia.Controllers
{

    public class TitlesController : BaseController
    {
        private readonly ITitleService _titleService;
        private readonly ICreditService _creditService;
        public TitlesController(ITitleService titleService, ICreditService creditService)
        {
            _titleService = titleService;
            _creditService = creditService;
        }

        /// <summary>
        /// Get titles
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTitles([FromQuery] TitleSearchRequest searchRequest)
        {
            var search = TitleSearch.ToDomain(searchRequest);
            var result = _titleService.TitleSearch(search);

            var titles = result.Results;
            var results = TitleResource.ToResource(titles);
            var data = results.ToPagedResponse(result.CurrentPage, result.PageSize, result.TotalCount);

            return Ok(data);
        }

        /// <summary>
        /// Get title by id
        /// </summary>
        /// <param name="title_id"></param>
        /// <returns></returns>
        [HttpGet("{title_id}")]
        public async Task<IActionResult> GetTitleById(int title_id)
        {
            var title = _titleService.GetTitleById(title_id);
            var result = TitleDetailResource.ToResource(title);
            return Ok(result);
        }

        /// <summary>
        /// Get credits for title
        /// </summary>
        /// <param name="title_id"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("{title_id}/credits")]
        public async Task<IActionResult> GetCredits(int title_id, [FromQuery] CreditSearch search)
        {
            search.title_id = title_id;
            search.participant_id = null;
            var result = _creditService.CreditSearch(search);
            var titleParticipants = result.Results;
            var results = CreditResource.ToResource(titleParticipants);
            var data = results.ToPagedResponse(result.CurrentPage, result.PageSize, result.TotalCount);
            return Ok(data);
        }
    }
}
