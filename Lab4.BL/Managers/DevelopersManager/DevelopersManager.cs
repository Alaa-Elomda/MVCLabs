using Lab4.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BL;

public class DevelopersManager : IDevelopersManager
{
    private readonly IDevelopersRepo _developersRepo;

    public DevelopersManager(IDevelopersRepo developersRepo)
    {
        _developersRepo = developersRepo;
    }

    IEnumerable<SelectListItem> IDevelopersManager.GetDevelopersListItems()
    {
        IEnumerable<Developer> developersFromDb = _developersRepo.GetAll();
        return developersFromDb.Select(d => new SelectListItem(d.FirstName + " " + d.LastName, d.Id.ToString()));
    }
}
