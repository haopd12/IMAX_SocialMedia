
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
	public class PostController : ControllerBase
	{
		private readonly ILogger<PostController> _logger;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public PostController(ILogger<PostController> logger, IMediator mediator, IMapper mapper)
		{
			_logger = logger;
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet("GetPostByAdmin")]
		public async Task<object?> GetPostByAdmin([FromQuery] long input)
		{
			try
			{
				var result = await _mediator.Send(new GetPostByAdminQuery() { Id = input });

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
		[HttpGet("GetListPost")]
		public async Task<object?> GetListPost([FromQuery] GetListPost input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListPostQuery>(input));

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
		[HttpGet("GetListSharedPost")]
		public async Task<object?> GetListSharedPost([FromQuery] long input)
		{
			try
			{
				var result = await _mediator.Send(new GetListSharedPostQuery() { SharedId = input });

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


		[HttpGet("GetListPostOfFanpage")]
		public async Task<object?> GetListPostOfFanpage([FromQuery] GetListPostOfFanpageDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListPostOfFanpageQuery>(input));

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
		[HttpGet("GetListPostOfGroup")]
		public async Task<object?> GetListPostOfGroup([FromQuery] GetListPostOfGroupDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListPostOfGroupQuery>(input));

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

		[HttpPost("CreatePost")]
		public async Task<object?> CreatePost([FromBody] CreatePostDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<CreatePostCommand>(input));

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
		[HttpPut("UpdatePost")]
		public async Task<object?> UpdatePost([FromBody] UpdatePostDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<UpdatePostCommand>(input));

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
		[HttpDelete("DeletePost")]
		public async Task<object?> DeletePost([FromBody] DeletePostDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<DeletePostCommand>(input));

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
