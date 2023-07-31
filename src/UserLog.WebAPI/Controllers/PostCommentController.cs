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
	public class PostCommentController: ControllerBase
	{
		private readonly ILogger<PostCommentController> _logger;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public PostCommentController(ILogger<PostCommentController> logger, IMediator mediator, IMapper mapper)
		{
			_logger = logger;
			_mediator = mediator;
			_mapper = mapper;
		}
		[HttpGet("GetListComment")]
		public async Task<object?> GetListParentComment([FromQuery] GetListCommentDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListCommentQuery>(input));

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
		[HttpPost("CreatePostComment")]
		public async Task<object?> CreatePostComment([FromBody] CreatePostCommentDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<CreatePostCommentCommand>(input));

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
		[HttpPut("UpdatePostComment")]
		public async Task<object?> UpdatePostComment([FromBody] UpdatePostCommentDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<UpdatePostCommentCommand>(input));

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
		[HttpDelete("DeletePostComment")]
		public async Task<object?> DeletePostComment([FromBody] DeletePostCommentDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<DeletePostCommentCommand>(input));

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
