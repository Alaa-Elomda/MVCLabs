using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab4.DAL;

public class TicketsRepo : ITicketsRepo
{
    private readonly IssuesContext _context;

    public TicketsRepo(IssuesContext context)
    {
        _context = context;
    }

    public void Add(Ticket ticket)
    {
        _context.Set<Ticket>().Add(ticket);
    }

    public Ticket? Get(int id)
    {
        return _context.Set<Ticket>().Find(id);
    }

    public IEnumerable<Ticket> GetAll()
    {
        return _context.Set<Ticket>()
            .Include(t => t.Department)
            .Include(t => t.Developers);
    }
    Ticket? ITicketsRepo.GetTicketWithDevelopersAndDepartment(int id)
    {
        return _context.Set<Ticket>()
    .Include(t => t.Department)
    .Include(t => t.Developers)
    .FirstOrDefault(t => t.Id == id);
    }

    Ticket? ITicketsRepo.GetTicketWithDevelopers(int id)
    {
        return _context.Set<Ticket>()
             .Include(t => t.Developers)
             .FirstOrDefault(t => t.Id == id);
    }

    public void Update(Ticket ticket)
    {

    }

    public void Delete(int id)
    {
        var ticketToDelete = Get(id);
        if (ticketToDelete != null)
        {
            _context.Set<Ticket>().Remove(ticketToDelete);
        }
    }


    public int SaveChanges()
    {
        return _context.SaveChanges();
    }




}
