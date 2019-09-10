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
    public class MerchantController : BaseController
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
            ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "AgentUserID");
            PopulateStatesDropDownList();
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MerchantUserID,PassWord,MerchantFullName,PhoneNumber,MerchantState,PrepaidRate,WithdrawalRate,Balance,Remark,AgentID")] Merchant merchant)
        {

            if (ModelState.IsValid)
            {
                merchant.Md5key = Guid.NewGuid().ToString();
                merchant.Operator = "admin";
                merchant.CreateTime = DateTime.Now;
                _context.Add(merchant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //保存失败时
            ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "AgentUserID", merchant.AgentID);
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
            ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "AgentUserID", merchant.AgentID);
            PopulateStatesDropDownList(merchant.MerchantState);
            return View(merchant);
        }

        // POST: Merchant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MerchantUserID,PassWord,MerchantFullName,PhoneNumber,MerchantState,PrepaidRate,WithdrawalRate,Balance,Md5key,Remark,AgentID")] Merchant merchant)
        {
            if (id != merchant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //设置 需要更新的列
                    _context.Attach(merchant);
                    _context.Entry(merchant).Property(d => d.PassWord).IsModified = true;
                    _context.Entry(merchant).Property(d => d.MerchantFullName).IsModified = true;
                    _context.Entry(merchant).Property(d => d.PhoneNumber).IsModified = true;
                    _context.Entry(merchant).Property(d => d.MerchantState).IsModified = true;
                    _context.Entry(merchant).Property(d => d.PrepaidRate).IsModified = true;
                    _context.Entry(merchant).Property(d => d.WithdrawalRate).IsModified = true;
                    _context.Entry(merchant).Property(d => d.Balance).IsModified = true;
                    _context.Entry(merchant).Property(d => d.Md5key).IsModified = true;
                    _context.Entry(merchant).Property(d => d.Remark).IsModified = true;
                    _context.Entry(merchant).Property(d => d.AgentID).IsModified = true;
                    _context.Entry(merchant).Property(d => d.LastUpdateTime).IsModified = true;
                    _context.Entry(merchant).Property(d => d.Operator).IsModified = true;
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
            ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "AgentUserID", merchant.AgentID);
            PopulateStatesDropDownList(merchant.MerchantState);
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
