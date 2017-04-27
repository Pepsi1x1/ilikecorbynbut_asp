using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILikeCorbynBut.Data;
using ILikeCorbynBut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ILikeCorbynBut.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FaqViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.FaqViewModel.ToListAsync());
        }

        // GET: FaqViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faqViewModel = await _context.FaqViewModel.SingleOrDefaultAsync(m => m.Id == id);
            if (faqViewModel == null)
            {
                return NotFound();
            }

            return View(faqViewModel);
        }

        // GET: FaqViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FaqViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Answer,DivId,Publish,Question,SubmittedOn")] FaqViewModel faqViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faqViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(faqViewModel);
        }

        // GET: FaqViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faqViewModel = await _context.FaqViewModel.SingleOrDefaultAsync(m => m.Id == id);
            if (faqViewModel == null)
            {
                return NotFound();
            }
            return View(faqViewModel);
        }

        // POST: FaqViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Answer,DivId,Publish,Question,SubmittedOn")] FaqViewModel faqViewModel)
        {
            if (id != faqViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faqViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaqViewModelExists(faqViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(faqViewModel);
        }

        // GET: FaqViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faqViewModel = await _context.FaqViewModel.SingleOrDefaultAsync(m => m.Id == id);
            if (faqViewModel == null)
            {
                return NotFound();
            }

            return View(faqViewModel);
        }

        // POST: FaqViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faqViewModel = await _context.FaqViewModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.FaqViewModel.Remove(faqViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FaqViewModelExists(int id)
        {
            return _context.FaqViewModel.Any(e => e.Id == id);
        }
    }
}
