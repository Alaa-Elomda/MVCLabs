using Lab4.BL;
using Lab4.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace Lab4.MVC.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsManager _ticketsManager;

        public TicketsController(ITicketsManager ticketsManager)
        {
            _ticketsManager = ticketsManager;
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
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Edit(TicketEditVM ticketVM)
        {
            _ticketsManager.Edit(ticketVM);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        public IActionResult Delete(TicketEditVM ticketVM)
        {
            _ticketsManager.Delete(ticketVM);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
