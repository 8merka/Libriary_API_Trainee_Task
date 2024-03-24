using Libriary_BAL.DTOs;
using Libriary_BAL.Services;
using Libriary_BAL.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace Libriary_API.Controllers
{
    [Route("api/[controller]")]
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
        [Route("GetAllFullBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllFullBiiksAsync(CancellationToken cancellationToken)
        {
            var books = await _issueService.GetAllFullBooksAsync(cancellationToken);
            return Ok(books.ToList());
        }

        [HttpGet]
        [Route("GetFullBookByISBN")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookByISBNAsync(int ISBN, CancellationToken cancellationToken)
        {
            var book = await _issueService.GetFullBookInfoByISBNAsync(ISBN, cancellationToken);
            return Ok(book);
        }
        [HttpGet]
        [Route("GetFullBookInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFullBookInfo(int id, CancellationToken cancellationToken)
        {
            var bookInfo = await _issueService.GetFullBookInfoAsync(id, cancellationToken);
            return Ok(bookInfo);
        }

        [HttpPost]
        [Route("CreateIssue")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateIssueAsync([FromBody] IssueToCreateDTO issueToCreateDTO)
        {
            await _issueService.CreateIssueAsync(issueToCreateDTO);
            return Created();
        }

        [HttpPut]
        [Route("UpdateIssue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateIssueAsync([FromBody] IssueToUpdateDTO issueToUpdateDTO)
        {
            await _issueService.UpdateIssueAsync(issueToUpdateDTO);
            return Ok(issueToUpdateDTO);
        }

        [HttpDelete]
        [Route("DeleteIssue")]
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
