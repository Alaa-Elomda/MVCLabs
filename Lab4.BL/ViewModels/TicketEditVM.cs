using Lab4.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BL;

public record TicketEditVM 
{

    public int Id { get; init; }
    [Required]
    [Remote(action: "ValidateTitle", controller: "Tickets")]

    public string Title { get; init; } 
    [Required]
    public string Description { get; init; } 
    public Severity Severity { get; init; }
    public int DepartmentId { get; init; }
    public int[] DevelopersIds { get; init; }
    public IFormFile? Image { get; set; }

    public string? ImagePath { get; set; }


    public TicketEditVM()
    {
    }

    public TicketEditVM(int _id, string _title, string _description, Severity _severity, int _departmentId, int[] _developers, string _imagePath)
    {
        Id = _id;
        Title = _title;
        Description = _description;
        Severity = _severity;
        DepartmentId = _departmentId;
        DevelopersIds = _developers;
        ImagePath = _imagePath;
    }

}
