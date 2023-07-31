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
	public class GroupController
	{
		private readonly ILogger<GroupController> _logger;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public GroupController(ILogger<GroupController> logger, IMediator mediator, IMapper mapper)
		{
			_logger = logger;
			_mediator = mediator;
			_mapper = mapper;
		}
		[HttpGet("GetListGroupByUser")]
		public async Task<object?> GetListGroup([FromQuery] GetListGroupByUserDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListGroupByUserQuery>(input));

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
		[HttpGet("GetListMemberOfGroup")]
		public async Task<object?> GetListMemberOfGroup([FromQuery] GetListMemberOfGroupDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<GetListMemberOfGroupQuery>(input));

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
		[HttpPost("CreateGroup")]
		public async Task<object?> CreateGroup([FromBody] CreateGroupByAdminDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<CreateGroupByAdminCommand>(input));

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
		[HttpPost("CreateMemberOfGroup")]
		public async Task<object?> CreateMemberOfGroup([FromBody] CreateMemberOfGroupDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<CreateMemberOfGroupCommand>(input));

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
		[HttpPut("UpdateGroup")]
		public async Task<object?> UpdateGroup([FromBody] UpdateGroupByAdminDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<UpdateGroupByAdminCommand>(input));

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
		[HttpPut("UpdateMemberOfGroup")]
		public async Task<object?> UpdateMemberOfGroup([FromBody] UpdateMemberOfGroupDto input)
		{
			try
			{
				var result = await _mediator.Send(_mapper.Map<UpdateMemberOfGroupCommand>(input));

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
		[HttpDelete("DeleteGroup")]
		public async Task<object?> DeleteGroup([FromBody] long input)
		{
			try
			{
				var result = await _mediator.Send(new DeleteGroupByAdminCommand() { Id = input });

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
		[HttpDelete("DeleteMemberOfGroup")]
		public async Task<object?> DeleteMemberOfGroup([FromBody] long input)
		{
			try
			{
				var result = await _mediator.Send(new DeleteMemberOfGroupCommand() { Id = input });

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
