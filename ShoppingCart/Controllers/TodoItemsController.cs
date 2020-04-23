using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class TodoItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TodoItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: TodoItems
        public async Task<ActionResult> Index(string filter)
        {

            var user = await GetCurrentUserAsync();


            var items = _context.TodoItem
          .Where(si => si.ApplicationUserId == user.Id);
       
            if (filter == "To-Do")
            {
                items = items.Where(tdi => tdi.TodoStatusId == 1)
                 .Include(ti => ti.TodoStatus);


                return View(items);
            }
            else if (filter == "In Progress")
            {

                items = items.Where(ti => ti.TodoStatusId == 2)
                    .Include(ti => ti.TodoStatus);

                return View(items);
            }
            else if (filter == "Done")
            {
                items = items.Where(ti => ti.TodoStatusId == 3)
                    .Include(ti => ti.TodoStatus);

                return View(items);
            }
            else
            {
                items = items.Include(tdi => tdi.TodoStatus);
                return View(items);
            }
        }

        // GET: TodoItems/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodoItems/Create
        public IActionResult Create()
        {
            ViewData["TodoStatusId"] = new SelectList(_context.TodoStatus, "Id", "Title");
            return View();
        }

        // POST: TodoItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TodoStatusId, Title")] TodoItem todoItem)
        {

            try
            {

                var user = await GetCurrentUserAsync();
                todoItem.ApplicationUserId = user.Id;

                var status = await _context.TodoStatus
             .Where(si => si.Id == todoItem.TodoStatusId)
             .ToListAsync();

                _context.TodoItem.Add(todoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch
            {

                return View();
            }
        }

        // GET: TodoItems/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TodoItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.TodoItem.Include(i => i.TodoStatus).FirstOrDefaultAsync(i => i.Id == id);

            return View(item);
        }

        // POST: TodoItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, TodoItem toDoItem)
        {
            try
            {

                _context.TodoItem.Remove(toDoItem);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
    }
