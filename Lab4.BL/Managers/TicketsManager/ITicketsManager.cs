using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BL;

public interface ITicketsManager
{
    List<TicketReadVM> GetAll();
    TicketReadVM? Get(int id);
    TicketEditVM? GetToEdit(int id);
    void Add(TicketAddVM ticket);
    void Edit(TicketEditVM ticket);

    void Delete(TicketEditVM ticket);

}
