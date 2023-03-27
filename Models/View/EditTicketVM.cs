using Lab02.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Lab02.Models.View
{
	public record EditTicketVM
	{
		public Guid Id { get; init; }
		[Display(Name ="Is Closed")]
		public bool IsClosed { get; init; }
		public Severity Severity { get; init; }
		public string Description { get; init; } = string.Empty;
		[Display(Name ="Department")]
		public Guid DepartmentId { get; init; }
	//	public int DepartmentId { get; init; }
		[Display(Name ="Developers")]
		public List<Guid> DevelopersIds { get; init; } = new();
		//public List<int> DevelopersIds { get; init; } = new();
	}
}
