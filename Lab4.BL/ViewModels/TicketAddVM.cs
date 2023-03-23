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

public record TicketAddVM 
{
    [Required]
    [Remote(action: "ValidateTitle", controller: "Tickets")]
    public string Title { get; init; } = string.Empty;
    [Required]
    public string Description { get; init; } = string.Empty;

    public Severity Severity { get; init; }

    public int DepartmentId { get; init; }
    [Required]
    public int[]? DevelopersIds { get; init; }

    public IFormFile? Image { get; set; } = null;

    public string? ImagePath { get; set; }


}
