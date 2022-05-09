using Ispit.ToDo.Data;
using Ispit.ToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.ToDo.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class TodotaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodotaskController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: TodotaskController
        public ActionResult Index(int todoListId)
        {
            return View(_context.TodoTasks.Where(task => task.TodolistId == todoListId).ToList());
        }

        // GET: TodotaskController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodotaskController/Create
        public ActionResult Create(int todoListId)
        {
            ViewBag.TodolistId = todoListId;
            return View();
        }

        // POST: TodotaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TodoTask task)
        {
            try
            {
                _context.TodoTasks.Add(task);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index), task.TodolistId);
            }
            catch
            {
                return View();
            }
        }

        // GET: TodotaskController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TodotaskController/Edit/5
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

        // GET: TodotaskController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TodotaskController/Delete/5
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
