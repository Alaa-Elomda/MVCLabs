using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.DAL;

public class CustomUser : IdentityUser
{
    [Column(TypeName = "date")]
    public DateTime DateOfBirth { get; set; }

}
