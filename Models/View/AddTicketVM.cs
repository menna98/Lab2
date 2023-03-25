using Lab02.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Lab02.Models.View
{
	public record AddTicketVM
	{
		[Display(Name ="Is Closed")]
		public bool IsClosed { get; init; }
		public Severity Severity { get; init; }
		public string Description { get; init; }
	}
}
