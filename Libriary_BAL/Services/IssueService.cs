using AutoMapper;
using Libriary_BAL.DTOs;
using Libriary_BAL.Services.IService;
using Libriary_DAL.Entities.Constants;
using Libriary_BAL.Utilities.Exceptions;
using Libriary_DAL.Entities.Models;
using Libriary_DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Libriary_BAL.Services
{
    public class IssueService(
        ILogger<IssueService> logger,
        IMapper mapper,
        IIssueRepository issueRepository
        ) : IIssueService
    {
        private readonly ILogger<IssueService> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IIssueRepository _issueRepository = issueRepository;

        public async Task<List<IssueDTO>> GetAllIssuesAsync(CancellationToken cancellationToken = default)
        {
            var issuesToReturn = await _issueRepository.GetListAsync(cancellationToken: cancellationToken);
            _logger.LogInformation("List of {Count} issues has been returned", issuesToReturn.Count);

            return _mapper.Map<List<IssueDTO>>(issuesToReturn);
        }

        public async Task<IssueDTO> GetFullBookInfo(int bookId, CancellationToken cancellationToken)
        {
            var issue = await _issueRepository.GetAsync(i => i.BookId == bookId, cancellationToken);

            if (issue == null)
            {
                _logger.LogError("Issue was not found");
                throw new NotFoundException(Messages.issueNotFound);
            }

            var issueDto = _mapper.Map<IssueDTO>(issue);
            return issueDto;
        }


        public async Task<IssueDTO> CreateIssueAsync(IssueDTO issueDTO)
        {
            _logger.LogInformation("Creating new issue {@IssueDTO}", issueDTO);

            var createdIssue = await _issueRepository.AddAsync(_mapper.Map<Issue>(issueDTO));

            return _mapper.Map<IssueDTO>(createdIssue);
        }

        public async Task<IssueDTO> UpdateIssueAsync(IssueToUpdateDTO issueToUpdateDTO)
        {
            var issue = await _issueRepository.GetAsync(x => x.IssueId == issueToUpdateDTO.IssueId);

            if (issue is null)
            {
                _logger.LogError("Issue with issueId = {IssueId} was not found", issueToUpdateDTO.IssueId);
                throw new NotFoundException(Messages.issueNotFound);
            }

            var issueToUpdate = _mapper.Map<Issue>(issueToUpdateDTO);

            _logger.LogInformation("Issue with these properties: {@issueToUpdate} has been updated", issueToUpdateDTO);
            return _mapper.Map<IssueDTO>(await _issueRepository.UpdateAsync(issueToUpdate));
        }

        public async Task DeleteIssueAsync(int id)
        {
            var issueToDelete = await _issueRepository.GetAsync(x => x.IssueId == id);
            if (issueToDelete is null)
            {
                _logger.LogError("Issue with issueId = {id} was not found", id);
                throw new NotFoundException(Messages.issueNotFound);
            }
            await _issueRepository.DeleteAsync(issueToDelete);
        }
    }
}
