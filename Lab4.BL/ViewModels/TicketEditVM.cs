using Lab4.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BL;

public record TicketEditVM (int Id, string Title, string Description, Severity Severity)
{
}
