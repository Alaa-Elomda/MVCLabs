using Lab4.BL;
using Lab4.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
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
        #region GET
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
        #endregion

        #region ADD
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
            if (!_ticketsManager.SaveImage(ticket.Image, ModelState, out string imageName))
            {
                return View();
            }

            ticket.ImagePath = imageName;
            _ticketsManager.Add(ticket);

            return RedirectToAction(nameof(GetAll));

        }
        #endregion

        #region EDIT
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
            if (_ticketsManager.SaveImage(ticketVM.Image, ModelState, out string imageName))
            {
                ticketVM.ImagePath = imageName;
                _ticketsManager.Edit(ticketVM);
                return RedirectToAction(nameof(GetAll), new { id = ticketVM.Id });
            }
            else
            {
                return View(ticketVM);
            }
        }
        #endregion

        #region DELETE
        [HttpPost]
        public IActionResult Delete(TicketEditVM ticketVM)
        {
            _ticketsManager.Delete(ticketVM);
            return RedirectToAction(nameof(GetAll));
        }
        #endregion

        #region Remote Title
        public IActionResult ValidateTitle(string title)
        {
            if (_ticketsManager.TitleCheck(title))
            {
                return Json($"{title} is taken");
            }
            return Json(true);
        }
        #endregion

    }
}
