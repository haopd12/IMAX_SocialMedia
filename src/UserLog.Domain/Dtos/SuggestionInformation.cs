using App.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Dtos
{
	public class SuggestionInformation: PagedInputDto
	{
		public long ForeignId { get; set; }
		public string Name { get; set; }
		public string? ImageUrl { get; set; }
	}
}
