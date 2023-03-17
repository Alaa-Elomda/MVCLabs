using Lab4.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BL;

public class DepartmentsManager : IDepartmentsManager
{
    private readonly IDepartmentsRepo _departmentsRepo;

    public DepartmentsManager(IDepartmentsRepo departmentsRepo)
    {
        _departmentsRepo = departmentsRepo;
    }

    IEnumerable<SelectListItem> IDepartmentsManager.GetDepartmentsListItems()
    {
         var departmentsFromDb = _departmentsRepo.GetAll();
        return departmentsFromDb.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
    }
}
