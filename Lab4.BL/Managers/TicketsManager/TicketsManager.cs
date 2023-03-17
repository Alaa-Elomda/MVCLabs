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
    private readonly IDevelopersRepo _developersRepo;

    public TicketsManager(ITicketsRepo ticketsRepo, IDevelopersRepo developersRepo)
    {
        _ticketsRepo = ticketsRepo;
        _developersRepo = developersRepo;
    }

    public List<TicketReadVM> GetAll()
    {
        var ticketsFromDB = _ticketsRepo.GetAll();
        return ticketsFromDB.Select(t => new TicketReadVM(t.Id,
                                    t.Title, t.Description, t.Severity,
                                    t.Department?.Name??"",t.Developers?.Count()??0)).ToList();

    }
    public TicketReadVM? Get(int id)
    {
        Ticket? ticketFromDB = _ticketsRepo.GetTicketWithDevelopersAndDepartment(id);
        if (ticketFromDB == null)
        {
            return null;
        }
        return new TicketReadVM(Id: ticketFromDB.Id,
                                Title: ticketFromDB.Title,
                                Description: ticketFromDB.Description,
                                Severity: ticketFromDB.Severity,
                                DepartmentName: ticketFromDB.Department?.Name ?? "",
                                DevelopersCount: ticketFromDB.Developers.Count
                                );
    }

    public void Add(TicketAddVM ticketVM)
    {
        var ticket = new Ticket
        {
            Title = ticketVM.Title,
            Description = ticketVM.Description,
            Severity = ticketVM.Severity,
            DepartmentId = ticketVM.DepartmentId,
            Developers = GetDevelopersByIds(ticketVM.DevelopersIds)
        };

        _ticketsRepo.Add(ticket);
        _ticketsRepo.SaveChanges();
    }

    public TicketEditVM? GetToEdit(int id)
    {
        var ticketFromDB = _ticketsRepo.GetTicketWithDevelopers(id);
        if (ticketFromDB == null)
        {
            return null;
        }
        return new TicketEditVM(Id: ticketFromDB.Id,
                                Title: ticketFromDB.Title,
                                Description: ticketFromDB.Description,
                                Severity: ticketFromDB.Severity,
                                DepartmentId: ticketFromDB.DepartmentId,
                                DevelopersIds: ticketFromDB.Developers.Select(i => i.Id).ToArray());
    }




    public void Edit(TicketEditVM ticketVM)
    {
        Ticket? ticketToEdit = _ticketsRepo.GetTicketWithDevelopers(ticketVM.Id);
        if (ticketToEdit == null) { return; }

        ticketToEdit.Id = ticketVM.Id;
        ticketToEdit.Title = ticketVM.Title;
        ticketToEdit.Description = ticketVM.Description;
        ticketToEdit.Severity = ticketVM.Severity;
        ticketToEdit.DepartmentId = ticketVM.DepartmentId;
        ticketToEdit.Developers = GetDevelopersByIds(ticketVM.DevelopersIds);

        _ticketsRepo.Update(ticketToEdit);
        _ticketsRepo.SaveChanges();

    }

    private ICollection<Developer> GetDevelopersByIds(int[] developersIds)
    {
        var developers = _developersRepo.GetAll();
        return developers.Where(d => developersIds.Contains(d.Id)).ToList();
    }

    public void Delete(TicketEditVM ticketVM)
    {
        _ticketsRepo.Delete(ticketVM.Id);
        _ticketsRepo.SaveChanges();
    }



}
