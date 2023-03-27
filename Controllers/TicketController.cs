using Lab02.Models.Domain;
using Lab02.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

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
			GetFormData();
			return View("Add");
		}
		[HttpPost]
		public IActionResult Add(AddTicketVM ticketVM) {
			var tickets = Ticket.GetTicketsList();

            var developers = Developer.GetDevelopers();
            var selectedDevelopersIds = ticketVM.DevelopersIds;
            var selectedDevelopers = developers.Where(d => selectedDevelopersIds.Contains(d.Id)).ToList();

            var TicketToAdd = new Ticket
			{
				Id = Guid.NewGuid(),
				Severity = ticketVM.Severity,
				Description = ticketVM.Description,
				IsClosed = ticketVM.IsClosed,
                Department = Department.GetDepartments().First(t => t.Id == ticketVM.DepartmentId),
                Developers = selectedDevelopers,
            };
			tickets.Add(TicketToAdd);
			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
		public IActionResult Edit(Guid id)
		{
			GetFormData();
			var ticketToEdit = Ticket.GetTicketsList().First(a => a.Id == id);
			var ticketVM = new EditTicketVM
			{
				Id = ticketToEdit.Id,
				Severity = ticketToEdit.Severity,
				Description = ticketToEdit.Description,
				IsClosed = ticketToEdit.IsClosed,
				DepartmentId = ticketToEdit.Department.Id,
				DevelopersIds = ticketToEdit.Developers.Select(a => a.Id).ToList(),
			};
			return View(ticketVM);
		}
		[HttpPost]
        public IActionResult Edit(EditTicketVM ticketVM)
        {
            var developers = Developer.GetDevelopers();
			var selectedDevelopersIds = ticketVM.DevelopersIds;
			var selectedDevelopers = developers.Where(d=>selectedDevelopersIds.Contains(d.Id)).ToList();

			var ticketToEdit = Ticket.GetTicketsList().First(a => a.Id == ticketVM.Id);

			ticketToEdit.Description = ticketVM.Description;
			ticketToEdit.IsClosed = ticketVM.IsClosed;
			ticketToEdit.Severity = ticketVM.Severity;
			ticketToEdit.Department = Department.GetDepartments().First(t => t.Id == ticketVM.DepartmentId);
			ticketToEdit.Developers = selectedDevelopers;
			

            return RedirectToAction(nameof(Index));
        }

		private void GetFormData()
		{
            #region Departments List Dropdown
            var departments = Department.GetDepartments();
            var departmentsList = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
            ViewBag.Departments = departmentsList;
            #endregion
            #region Developers List Multi-Select

            var developers = Developer.GetDevelopers();
            var developersList = developers.Select(dev => new SelectListItem(dev.FirstName, dev.Id.ToString()));
            ViewBag.developersList = developersList;
            #endregion
        }
    }
}
