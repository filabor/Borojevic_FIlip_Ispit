using Ispit.ToDo.Data;
using Ispit.ToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.ToDo.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class TodolistController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public TodolistController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: TodolistController
        public ActionResult Index()
        {

            return View(_context.Todolists.ToList());
        }

        // GET: TodolistController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodolistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodolistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Todolist list)
        {
            try
            {
                list.User = await _userManager.GetUserAsync(User);

                _context.Todolists.Add(list);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodolistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TodolistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodolistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TodolistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
