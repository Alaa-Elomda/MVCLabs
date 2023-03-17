using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL;

public interface IDepartmentsRepo
{
    IEnumerable<Department> GetAll();
}
