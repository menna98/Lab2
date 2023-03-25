using Lab02.Models.Domain;
using Lab02.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace Lab02.Controllers
{
	public class TicketController : Controller
	{
		public IActionResult Index()
		{
			var tickets = Ticket.GetTicketsList();

			return View(tickets);
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View("Add");
		}
		[HttpPost]
		public IActionResult Add(AddTicketVM ticketVM) {
			var tickets = Ticket.GetTicketsList();
			var TicketToAdd = new Ticket
			{
				Id = Guid.NewGuid(),
				Severity = ticketVM.Severity,
				Description = ticketVM.Description
			};
			tickets.Add(TicketToAdd);
			return RedirectToAction(nameof(Index));
		}

	}
}
