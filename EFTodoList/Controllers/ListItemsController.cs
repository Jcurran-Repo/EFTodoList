﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFTodoList.Data;
using EFTodoList.Models;

namespace EFTodoList.Controllers
{
    public class ListItemsController : Controller
    {
        private readonly EFTodoContext _context;

        public ListItemsController(EFTodoContext context)
        {
            _context = context;
        }

        // GET: ListItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListItem.OrderBy(i => i.ListItemOrder).ToListAsync());
        }

        // GET: ListItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listItem = await _context.ListItem
                .FirstOrDefaultAsync(m => m.ID == id);
            if (listItem == null)
            {
                return NotFound();
            }

            return View(listItem);
        }

        // GET: ListItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ListItemOrder,Description,IsComplete")] ToDoListItem listItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listItem);
        }

        // GET: ListItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listItem = await _context.ListItem.FindAsync(id);
            if (listItem == null)
            {
                return NotFound();
            }
            return View(listItem);
        }

        // POST: ListItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ListItemOrder,Description,IsComplete")] ToDoListItem listItem)
        {
            if (id != listItem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListItemExists(listItem.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(listItem);
        }

        // GET: ListItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listItem = await _context.ListItem
                .FirstOrDefaultAsync(m => m.ID == id);
            if (listItem == null)
            {
                return NotFound();
            }

            return View(listItem);
        }

        // POST: ListItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listItem = await _context.ListItem.FindAsync(id);
            _context.ListItem.Remove(listItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListItemExists(int id)
        {
            return _context.ListItem.Any(e => e.ID == id);
        }
    }
}
