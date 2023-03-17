using Lab4.BL;
using Lab4.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace Lab4.MVC.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsManager _ticketsManager;
        private readonly IDepartmentsManager _departmentsManager;
        private readonly IDevelopersManager _developersManager;

        public TicketsController(ITicketsManager ticketsManager,
                                 IDepartmentsManager departmentsManager, 
                                 IDevelopersManager developersManager)
        {
            _ticketsManager = ticketsManager;
            _departmentsManager = departmentsManager;
            _developersManager = developersManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return View(_ticketsManager.GetAll());
        }

        public IActionResult GetDetails(int id)
        {
            var ticket = _ticketsManager.Get(id);
            if (ticket is null)
            {
                View("NotFoundDeveloper");
            }
            return View(ticket);

        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Departments = _departmentsManager.GetDepartmentsListItems();
            ViewBag.Developers = _developersManager.GetDevelopersListItems();
            return View();
        }

        [HttpPost]
        public IActionResult Add(TicketAddVM ticket)
        {
            _ticketsManager.Add(ticket);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ticket = _ticketsManager.GetToEdit(id);
            ViewBag.Departments = _departmentsManager.GetDepartmentsListItems();
            ViewBag.Developers = _developersManager.GetDevelopersListItems();
            return View(ticket);

        }

        [HttpPost]
        public IActionResult Edit(TicketEditVM ticketVM)
        {
            _ticketsManager.Edit(ticketVM);
            return RedirectToAction(nameof(GetAll), new { id = ticketVM.Id });
        }

        [HttpPost]
        public IActionResult Delete(TicketEditVM ticketVM)
        {
            _ticketsManager.Delete(ticketVM);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
