using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Dtos
{
	public class CreateUserSelectionDto
	{
		public long UserId { get; set; }
		public long ForeignId { get; set; }
		public TypeOPost TypeOSuggestion { get; set; }
		public bool IsChoosen { get; set; }
	}
}
