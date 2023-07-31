using App.Shared.AppSession;
using App.Shared.Uow;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;
using UserLog.Domain.ICommands;
using UserLog.Domain.Repositories;

namespace UserLog.Application.CommandHandlers
{
	public class CreateUserSelectionCommandHandler: IRequestHandler<CreateUserSelectionCommand, bool>
	{
		private readonly IAppSession _appSession;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly ISuggestionRepository _suggestionRepository;
		public CreateUserSelectionCommandHandler(IAppSession appSession, IMapper mapper, 
			ISuggestionRepository suggestionRepository, IMaxUnitOfWork unitOfWork )
		{
			_appSession = appSession;
			_suggestionRepository = suggestionRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			
		}
		public async Task<bool> Handle(CreateUserSelectionCommand command, CancellationToken cancellationToken)
		{
			var input = _mapper.Map<Suggestion>(command);
			input.TenantId = _appSession.TenantId;

			await _suggestionRepository.InsertAsync(input);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}

	}
}
