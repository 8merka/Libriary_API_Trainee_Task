using Libriary_BAL.DTOs;
using Libriary_BAL.Services;
using Libriary_BAL.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/issue")]
    [ApiController]
    public class IssueController(IIssueService issueService) : ControllerBase
    {
        private readonly IIssueService _issueService = issueService;

        //[HttpGet]
        //[Route("GetAllIssues")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetAllIssuesAsync(CancellationToken cancellationToken)
        //{
        //    var issues = await _issueService.GetAllIssuesAsync(cancellationToken);
        //    return Ok(issues.ToList());
        //}

        [HttpGet]
        [ActionName("GetAllFullBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllFullBiiksAsync(CancellationToken cancellationToken)
        {
            var books = await _issueService.GetAllFullBooksAsync(cancellationToken);
            return Ok(books.ToList());
        }

        [HttpGet]
        [ActionName("GetFullBookByISBN")]
        [Route("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookByISBNAsync([FromRoute] int isbn, CancellationToken cancellationToken)
        {
            var book = await _issueService.GetFullBookInfoByISBNAsync(isbn, cancellationToken);
            return Ok(book);
        }
        [HttpGet]
        [ActionName("GetFullBookInfo")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFullBookInfo([FromRoute] int id, CancellationToken cancellationToken)
        {
            var bookInfo = await _issueService.GetFullBookInfoAsync(id, cancellationToken);
            return Ok(bookInfo);
        }

        [HttpPost]
        [ActionName("CreateIssue")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateIssueAsync([FromBody] IssueToCreateDTO issueToCreateDTO)
        {
            await _issueService.CreateIssueAsync(issueToCreateDTO);
            return Created();
        }

        [HttpPut]
        [ActionName("UpdateIssue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateIssueAsync([FromBody] IssueToUpdateDTO issueToUpdateDTO)
        {
            await _issueService.UpdateIssueAsync(issueToUpdateDTO);
            return Ok(issueToUpdateDTO);
        }

        [HttpDelete]
        [ActionName("DeleteIssue")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteIssueAsync(int id)
        {
            await _issueService.DeleteIssueAsync(id);
            return Ok();
        }
    }
}
