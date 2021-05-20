using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buffet.Data;
using Buffet.Models.Buffet.Local;

namespace Buffet.Controllers
{
    public class LocalController : Controller
    {
        private readonly DatabaseContext _context;

        public LocalController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Local
        public async Task<IActionResult> Index(string? descricao)
        {
            IQueryable<LocalEntity> locais;
            locais = descricao != null ? _context.Locais.Where(l => l.Descricao.Contains(descricao)) : _context.Locais;
            
            return View(await locais.ToListAsync());
        }

        // GET: Local/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localEntity = await _context.Locais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localEntity == null)
            {
                return NotFound();
            }

            localEntity.Eventos = await _context.Eventos.Where(e => e.LocalEntityId.Equals(localEntity.Id)).ToListAsync();
            return View(localEntity);
        }

        // GET: Local/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Local/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Endereco")] LocalEntity localEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localEntity);
        }

        // GET: Local/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localEntity = await _context.Locais.FindAsync(id);
            if (localEntity == null)
            {
                return NotFound();
            }
            return View(localEntity);
        }

        // POST: Local/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Endereco")] LocalEntity localEntity)
        {
            if (id != localEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalEntityExists(localEntity.Id))
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
            return View(localEntity);
        }

        // GET: Local/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localEntity = await _context.Locais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localEntity == null)
            {
                return NotFound();
            }

            return View(localEntity);
        }

        // POST: Local/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localEntity = await _context.Locais.FindAsync(id);
            var eventos = await _context.Eventos.Where(e => e.ClienteId.Equals(localEntity.Id)).ToListAsync();
            if (eventos.Count == 0)
            {
                _context.Locais.Remove(localEntity);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool LocalEntityExists(int id)
        {
            return _context.Locais.Any(e => e.Id == id);
        }
    }
}
