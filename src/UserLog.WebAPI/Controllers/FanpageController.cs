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
	public class FanpageController: ControllerBase
	{
		private readonly ILogger<FanpageController> _logger;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public FanpageController(ILogger<FanpageController> logger, IMediator mediator, IMapper mapper)
		{
			_logger = logger;
			_mediator = mediator;
			_mapper = mapper;
		}
		[HttpGet("GetListFanpageByUser")]
		public async Task<object?> GetListFanpage([FromQuery] GetListFanpageByUserDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListFanpageByUserQuery>(input));

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
		[HttpGet("GetListCensorOfFanpage")]
		public async Task<object?> GetListCensorOfFanpage([FromQuery] GetListCensorOfFanpageDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListCensorOfFanpageQuery>(input));

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
		[HttpPost("CreateFanpage")]
		public async Task<object?> CreateFanpage([FromBody] CreateFanpageByAdminDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<CreateFanpageByAdminCommand>(input));

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
		[HttpPost("CreateCensorOfFanpage")]
		public async Task<object?> CreateCensorOfFanpage([FromBody] CreateCensorOfFanpageDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<CreateCensorOfFanpageCommand>(input));

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
		[HttpPut("UpdateFanpage")]
		public async Task<object?> UpdateFanpage([FromBody] UpdateFanpageByAdminDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<UpdateFanpageByAdminCommand>(input));

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
		[HttpPut("UpdateCensorOfFanpage")]
		public async Task<object?> UpdateCensorOfFanpage([FromBody] UpdateCensorOfFanpageDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<UpdateCensorOfFanpageCommand>(input));

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
		[HttpDelete("DeleteFanpage")]
		public async Task<object?> DeleteFanpage([FromBody] long input)
		{
			try
			{
				var result = await _mediator.Send(new DeleteFanpageByAdminCommand() { Id = input });

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
		[HttpDelete("DeleteCensorOfFanpage")]
		public async Task<object?> DeleteCensorOfFanpage([FromBody] long input)
		{
			try
			{
				var result = await _mediator.Send(new DeleteCensorByAdminCommand() { Id = input });

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
