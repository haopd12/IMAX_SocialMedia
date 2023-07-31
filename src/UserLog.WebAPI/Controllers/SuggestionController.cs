using App.Shared.Controllers;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserLog.Domain.Dtos;
using UserLog.Domain.ICommands;
using UserLog.Domain.IQueries;

namespace UserLog.WebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SuggestionController: ControllerBase
	{
		private readonly ILogger<SuggestionController> _logger;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public SuggestionController(ILogger<SuggestionController> logger, IMediator mediator, IMapper mapper)
		{
			_logger = logger;
			_mediator = mediator;
			_mapper = mapper;
		}
		[HttpGet("GetListSuggestion")]
		public async Task<object?> GetListFriend([FromQuery] GetListSuggestionDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListSuggestionQuery>(input));

				return new ApiResult
				{
					Success = true,
					Result = result
				};
			}
			catch (Exception e)
			{
				_logger.LogError(e, e.Message);

				return new ApiResult
				{
					Success = false,
					Message = e.Message
				};
			}
		}
		[HttpPost("CreateUserSelection")]
		public async Task<object?> CreateUserSelection([FromBody] CreateUserSelectionDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<CreateUserSelectionCommand>(input));

				return new ApiResult
				{
					Success = true,
					Result = result
				};
			}
			catch (Exception e)
			{
				_logger.LogError(e, e.Message);

				return new ApiResult
				{
					Success = false,
					Result = false,
					Message = e.Message
				};
			}
		}
	}
}
