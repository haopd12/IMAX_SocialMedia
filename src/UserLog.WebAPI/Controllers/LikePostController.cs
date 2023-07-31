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
	public class LikePostController: ControllerBase
	{
		private readonly ILogger<LikePostController> _logger;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public LikePostController(ILogger<LikePostController> logger, IMediator mediator, IMapper mapper)
		{
			_logger = logger;
			_mediator = mediator;
			_mapper = mapper;
		}
		[HttpGet("GetListLikePost")]
		public async Task<object?> GetListPost([FromQuery] GetListLikePost input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListLikePostQuery>(input));

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
		[HttpPost("CreateLikePost")]
		public async Task<object?> CreateLikePost([FromBody] CreateLikePostDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<CreateLikePostCommand>(input));

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
		[HttpPut("UpdateLikePost")]
		public async Task<object?> UpdateLikePost([FromBody] UpdateLikePostDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<UpdateLikePostCommand>(input));

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
		[HttpDelete("DeleteLikePost")]
		public async Task<object?> DeleteLikePost([FromBody] DeleteLikePostDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<DeleteLikePostCommand>(input));

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

