using Libriary_BAL.DTOs;
using Libriary_BAL.Services;
using Libriary_BAL.Services.IService;
using Libriary_BAL.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetAllFullBooksAsync(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 10)
        {
            var books = await _issueService.GetAllFullBooksAsync(pageNumber, pageSize, cancellationToken);
            return Ok(books.ToList());
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet("isbn/{isbn}")]
        [ActionName("GetFullBookByISBN")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookByISBNAsync([FromRoute] int isbn, CancellationToken cancellationToken)
        {
            var book = await _issueService.GetFullBookInfoByISBNAsync(isbn, cancellationToken);
            return Ok(book);
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet("id/{id}")]
        [ActionName("GetFullBookInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFullBookInfo([FromRoute] int id, CancellationToken cancellationToken)
        {
            var bookInfo = await _issueService.GetFullBookInfoAsync(id, cancellationToken);
            return Ok(bookInfo);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [ActionName("CreateIssue")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateIssueAsync([FromBody] IssueToCreateDTO issueToCreateDTO, CancellationToken cancellationToken = default)
        {
            await _issueService.CreateIssueAsync(issueToCreateDTO, cancellationToken);
            return Created();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        [ActionName("UpdateIssue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateIssueAsync([FromBody] IssueToUpdateDTO issueToUpdateDTO, CancellationToken cancellationToken = default)
        {
            await _issueService.UpdateIssueAsync(issueToUpdateDTO, cancellationToken);
            return Ok(issueToUpdateDTO);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete]
        [ActionName("DeleteIssue")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteIssueAsync([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            await _issueService.DeleteIssueAsync(id, cancellationToken);
            return Ok();
        }
    }
}
