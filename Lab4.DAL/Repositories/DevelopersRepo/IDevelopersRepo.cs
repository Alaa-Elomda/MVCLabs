﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL;

public interface IDevelopersRepo
{
    IEnumerable<Developer> GetAll();
}