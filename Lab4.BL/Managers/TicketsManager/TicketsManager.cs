using Lab4.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BL;

public class TicketsManager : ITicketsManager
{
    private readonly ITicketsRepo _ticketsRepo;
    private readonly IDevelopersRepo _developersRepo;
    private readonly IOptionsMonitor<ImagesOptions> _imagesOptionsMonitor;

    public TicketsManager(ITicketsRepo ticketsRepo, IDevelopersRepo developersRepo, IOptionsMonitor<ImagesOptions> ImagesOptionsMonitor)
    {
        _ticketsRepo = ticketsRepo;
        _developersRepo = developersRepo;
        _imagesOptionsMonitor = ImagesOptionsMonitor;
    }

    #region GET
    public List<TicketReadVM> GetAll()
    {
        var ticketsFromDB = _ticketsRepo.GetAll();
        return ticketsFromDB.Select(t => new TicketReadVM(t.Id,
                                    t.Title, t.Description, t.Severity,
                                    t.Department?.Name??"",t.Developers?.Count()??0, t.Image)).ToList();

    }
    public TicketReadVM? Get(int id)
    {
        Ticket? ticketFromDB = _ticketsRepo.GetTicketWithDevelopersAndDepartment(id);
        if (ticketFromDB == null)
        {
            return null;
        }
        return new TicketReadVM(Id: ticketFromDB.Id,
                                Title: ticketFromDB.Title,
                                Description: ticketFromDB.Description,
                                Severity: ticketFromDB.Severity,
                                DepartmentName: ticketFromDB.Department?.Name ?? "",
                                DevelopersCount: ticketFromDB.Developers.Count,
                                Image: ticketFromDB.Image
                                );
    }
    #endregion

    #region ADD
    public void Add(TicketAddVM ticketVM)
    {
        var ticket = new Ticket
        {
            Title = ticketVM.Title,
            Description = ticketVM.Description,
            Severity = ticketVM.Severity,
            DepartmentId = ticketVM.DepartmentId,
            Developers = GetDevelopersByIds(ticketVM.DevelopersIds),
            Image = ticketVM.ImagePath
        };

        _ticketsRepo.Add(ticket);
        _ticketsRepo.SaveChanges();
    }
    #endregion

    #region Edit
    public TicketEditVM? GetToEdit(int id)
    {
        var ticketFromDB = _ticketsRepo.GetTicketWithDevelopers(id);
        if (ticketFromDB == null)
        {
            return null;
        }
        return new TicketEditVM(ticketFromDB.Id,
                                ticketFromDB.Title,
                                ticketFromDB.Description,
                                ticketFromDB.Severity,
                                ticketFromDB.DepartmentId,
                                ticketFromDB.Developers.Select(i => i.Id).ToArray(),
                                ticketFromDB.Image);
    }

    public void Edit(TicketEditVM ticketVM)
    {
        Ticket? ticketToEdit = _ticketsRepo.GetTicketWithDevelopers(ticketVM.Id);
        if (ticketToEdit == null) { return; }

        ticketToEdit.Id = ticketVM.Id;
        ticketToEdit.Title = ticketVM.Title;
        ticketToEdit.Description = ticketVM.Description;
        ticketToEdit.Severity = ticketVM.Severity;
        ticketToEdit.DepartmentId = ticketVM.DepartmentId;
        ticketToEdit.Developers = GetDevelopersByIds(ticketVM.DevelopersIds);
        ticketToEdit.Image = ticketVM.ImagePath;


        _ticketsRepo.Update(ticketToEdit);
        _ticketsRepo.SaveChanges();

    }
    

    private ICollection<Developer> GetDevelopersByIds(int[] developersIds)
    {
        var developers = _developersRepo.GetAll();
        return developers.Where(d => developersIds.Contains(d.Id)).ToList();
    }
    #endregion

    #region DELETE
    public void Delete(TicketEditVM ticketVM)
    {
        _ticketsRepo.Delete(ticketVM.Id);
        _ticketsRepo.SaveChanges();
    }
    #endregion

    #region Title Validation
    public bool TitleCheck(string title)
    {
        return _ticketsRepo.TicketExists(title);
    }
    #endregion

    #region Handel Image
    public bool TrySaveImage(IFormFile image, ModelStateDictionary modelState, out string imageName)
    {
        ImagesOptions imagesOptions = _imagesOptionsMonitor.CurrentValue;
        imageName = null;

        if (image is null)
        {
            modelState.AddModelError("", "Image is not found");
            return false;
        }

        if (image.Length > imagesOptions.Size)
        {
            modelState.AddModelError("", "Image size exceeded the limit");
            return false;
        }

        var allowedExtensions = imagesOptions.Allowed.Split(',');
        var sentExtension = Path.GetExtension(image.FileName).ToLower();

        if (!allowedExtensions.Contains(sentExtension))
        {
            modelState.AddModelError("", "Image extension is not valid");
            return false;
        }

        imageName = $"{Guid.NewGuid()}{sentExtension}";
        string fullPath = @$"{imagesOptions.Folder}{imageName}";

        using (var stream = System.IO.File.Create(fullPath))
        {
            image.CopyTo(stream);
        }

        return true;
    }


    #endregion

}
