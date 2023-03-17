using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BL;

public interface IDepartmentsManager
{
    IEnumerable<SelectListItem> GetDepartmentsListItems();
}
