using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FGPay.Manager;
using FGPay.Models;

namespace FGPay.Manager.Controllers
{
    public class SystemMenusController : BaseController
    {
        private readonly FGPayContext _context;

        public SystemMenusController(FGPayContext context)
        {
            _context = context;
        }

        // GET: SystemMenus
        public async Task<IActionResult> Index()
        {
            return View(await _context.SystemMenu.OrderByDescending(x=>x.Sort).ToListAsync());
        }

        // GET: SystemMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemMenu = await _context.SystemMenu
                .FirstOrDefaultAsync(m => m.MenuID == id);
            if (systemMenu == null)
            {
                return NotFound();
            }

            return View(systemMenu);
        }

        // GET: SystemMenus/Create
        public IActionResult Create()
        {
            BindParentMenus();
            PopulateStatesDropDownList();
            return View();
        }

        // POST: SystemMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuID,MenuTag,Name,Parentid,Icon,Controller,Action,Target,Href,State,Sort")] SystemMenu systemMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(systemMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(systemMenu);
        }

        // GET: SystemMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemMenu = await _context.SystemMenu.FindAsync(id);
            if (systemMenu == null)
            {
                return NotFound();
            }
            if (systemMenu.Parentid == 0)
            {

            }
            BindParentMenus();
            PopulateStatesDropDownList();
            return View(systemMenu);
        }

        private void BindParentMenus()
        {
            var items = _context.SystemMenu.Where(x => x.Parentid == 0).ToList();
            items.Insert(0, new SystemMenu { MenuID = 0, Name = "--根--" });
            ViewBag.Parentid = new SelectList(items.AsEnumerable(), "MenuID", "Name");
        }

        // POST: SystemMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuID,MenuTag,Name,Parentid,Icon,Controller,Action,Target,Href,State,Sort")] SystemMenu systemMenu)
        {
            if (id != systemMenu.MenuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemMenuExists(systemMenu.MenuID))
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
            return View(systemMenu);
        }

        // GET: SystemMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemMenu = await _context.SystemMenu
                .FirstOrDefaultAsync(m => m.MenuID == id);
            if (systemMenu == null)
            {
                return NotFound();
            }

            return View(systemMenu);
        }

        // POST: SystemMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var systemMenu = await _context.SystemMenu.FindAsync(id);
            _context.SystemMenu.Remove(systemMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemMenuExists(int id)
        {
            return _context.SystemMenu.Any(e => e.MenuID == id);
        }

        public IActionResult Menu(string pg)
        {
            ViewData["Page"] = pg;
            //调整：先从缓存中读取
            var currentMenus = _context.SystemMenu.Where(x => x.MenuTag == 1 && x.State == 1).OrderByDescending(x => x.Sort).AsEnumerable();
           
            return PartialView("_Menu", currentMenus);
        }
    }
}
