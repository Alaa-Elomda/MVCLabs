using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL;

public class DepartmentsRepo : IDepartmentsRepo
{
    private readonly IssuesContext _context;

    public DepartmentsRepo (IssuesContext context)
    {
        _context = context;
    }

    public IEnumerable<Department> GetAll()
    {
        return _context.Set<Department>();
    }
}
