﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL;

public class DevelopersRepo : IDevelopersRepo
{
    private readonly IssuesContext _context;

    public DevelopersRepo(IssuesContext context)
    {
        _context = context;
    }

    IEnumerable<Developer> IDevelopersRepo.GetAll()
    {
        return _context.Set<Developer>();
    }
}