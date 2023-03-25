namespace Lab02.Models.Domain;

public class Ticket
{
	public Guid Id { get; set; }
	public DateTime	CreatedDate { get; set; }
	public bool IsClosed { get; set; }
	public Severity Severity { get; set; }
	public string Description { get; set; } = string.Empty;

	public Ticket()
	{

	}

	public Ticket(Guid id ,DateTime date , bool isclosed , Severity s, string d)
	{
		Id= id;
		CreatedDate = date;
		IsClosed= isclosed;
		Severity = s;
		Description = d;
	}
	private static readonly List<Ticket> _ticketList = new()
	{
		new Ticket(Guid.NewGuid(),new DateTime(2013, 10, 21),true,Severity.High,"Ticket1"),
		new Ticket(Guid.NewGuid(),new DateTime(2020, 11, 23),false,Severity.Low,"Ticket2"),
		new Ticket(Guid.NewGuid(),new DateTime(2015, 2, 2),true,Severity.Medium,"Ticket3"),
		new Ticket(Guid.NewGuid(),new DateTime(2012, 5, 12),false,Severity.Low,"Ticket4"),
		new Ticket(Guid.NewGuid(),new DateTime(2011, 6, 23),true,Severity.High,"Ticket5"),
		new Ticket(Guid.NewGuid(),new DateTime(2023, 4, 13),false,Severity.Medium,"Ticket6"),
	};
	public static List<Ticket> GetTicketsList() => _ticketList;
}
