using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL;

public interface ITicketsRepo
{
    IEnumerable<Ticket> GetAll();
    Ticket? Get(int id);
    void Add(Ticket ticket);
    void Update(Ticket ticket);
    void Delete(int id);
    int SaveChanges();



}
