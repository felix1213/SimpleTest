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
    public class MerchantController : Controller
    {
        private readonly FGPayContext _context;

        public MerchantController(FGPayContext context)
        {
            _context = context;
        }

        // GET: Merchant
        public async Task<IActionResult> Index()
        {
            var fGPayContext = _context.Merchants.Include(m => m.MerchantAgent);
            return View(await fGPayContext.ToListAsync());
        }

        // GET: Merchant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants
                .Include(m => m.MerchantAgent)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (merchant == null)
            {
                return NotFound();
            }

            return View(merchant);
        }

        // GET: Merchant/Create
        public IActionResult Create()
        {
            ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "AgentID");
            return View();
        }

        // POST: Merchant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MerchantUserID,PassWord,MerchantFullName,PhoneNumber,MerchantState,SettleType,Role,PrepaidRate,WithdrawalRate,Balance,Md5key,Remark,Operator,CreateTime,LastUpdateTime,LastLoginTime,ClientIP,AgentID")] Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merchant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "AgentID", merchant.AgentID);
            return View(merchant);
        }

        // GET: Merchant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants.FindAsync(id);
            if (merchant == null)
            {
                return NotFound();
            }
            ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "AgentID", merchant.AgentID);
            return View(merchant);
        }

        // POST: Merchant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MerchantUserID,PassWord,MerchantFullName,PhoneNumber,MerchantState,SettleType,Role,PrepaidRate,WithdrawalRate,Balance,Md5key,Remark,Operator,CreateTime,LastUpdateTime,LastLoginTime,ClientIP,AgentID")] Merchant merchant)
        {
            if (id != merchant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merchant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerchantExists(merchant.ID))
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
            ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "AgentID", merchant.AgentID);
            return View(merchant);
        }

        // GET: Merchant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants
                .Include(m => m.MerchantAgent)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (merchant == null)
            {
                return NotFound();
            }

            return View(merchant);
        }

        // POST: Merchant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merchant = await _context.Merchants.FindAsync(id);
            _context.Merchants.Remove(merchant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerchantExists(int id)
        {
            return _context.Merchants.Any(e => e.ID == id);
        }
    }
}
