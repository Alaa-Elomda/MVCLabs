using Lab4.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BL;

public class TicketsManager : ITicketsManager
{
    private readonly ITicketsRepo _ticketsRepo;

    public TicketsManager(ITicketsRepo ticketsRepo)
    {
        _ticketsRepo = ticketsRepo;
    }

    public List<TicketReadVM> GetAll()
    {
        var ticketsFromDB = _ticketsRepo.GetAll();
        return ticketsFromDB.Select(t => new TicketReadVM(t.Id, t.Title, t.Description, t.Severity))
            .ToList();
    }
    public TicketReadVM? Get(int id)
    {
        var ticketFromDB = _ticketsRepo.Get(id);
        if (ticketFromDB == null)
        {
            return null;
        }
        return new TicketReadVM(ticketFromDB.Id, ticketFromDB.Title, ticketFromDB.Description, ticketFromDB.Severity);
    }

    public void Add(TicketAddVM ticketVM)
    {
        var ticket = new Ticket
        {
            Title = ticketVM.Title,
            Description = ticketVM.Description,
            Severity = ticketVM.Severity
        };

        _ticketsRepo.Add(ticket);
        _ticketsRepo.SaveChanges();
    }

    public TicketEditVM? GetToEdit(int id)
    {
        var ticketFromDB = _ticketsRepo.Get(id);
        if (ticketFromDB == null)
        {
            return null;
        }
        return new TicketEditVM(ticketFromDB.Id, ticketFromDB.Title, ticketFromDB.Description, ticketFromDB.Severity);
    }

    public void Edit(TicketEditVM ticketVM)
    {
        var ticketToEdit = _ticketsRepo.Get(ticketVM.Id);

        ticketToEdit.Id = ticketVM.Id;
        ticketToEdit.Title = ticketVM.Title;
        ticketToEdit.Description = ticketVM.Description;
        ticketToEdit.Severity = ticketVM.Severity;


        _ticketsRepo.SaveChanges();

    }

    public void Delete(TicketEditVM ticketVM)
    {
        _ticketsRepo.Delete(ticketVM.Id);
        _ticketsRepo.SaveChanges();
    }



}
