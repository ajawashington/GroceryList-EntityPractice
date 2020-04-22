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


        // GET: TodoItems
        public async Task<IActionResult> Index()
        {

            var user = await GetCurrentUserAsync();
            var items = await _context.TodoItem
                .Where(si => si.ApplicationUserId == user.Id)
                .ToListAsync();

            return View(items);

        }

        // GET: TodoItems/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var todoItem = await _context.TodoItem
        //        .Include(t => t.ApplicationUser)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (todoItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return View();
        //}

        // GET: TodoItems/Create
        public IActionResult Create()
        {
     
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
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var todoItem = await _context.TodoItem.FindAsync(id);
        //    if (todoItem == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", todoItem.ApplicationUserId);
        //    return View(todoItem);
        //}

        // POST: TodoItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,TodoStatusId,ApplicationUserId")] TodoItem todoItem)
        //{
        //    if (id != todoItem.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(todoItem);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TodoItemExists(todoItem.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", todoItem.ApplicationUserId);
        //    return View(todoItem);
        //}

        // GET: TodoItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _context.TodoItem
                .Include(t => t.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        // POST: TodoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todoItem = await _context.TodoItem.FindAsync(id);
            _context.TodoItem.Remove(todoItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoItemExists(int id)
        {
            return _context.TodoItem.Any(e => e.Id == id);
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
