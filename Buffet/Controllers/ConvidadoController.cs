using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buffet.Data;
using Buffet.Models.Buffet.Convidado;

namespace Buffet.Controllers
{
    public class ConvidadoController : Controller
    {
        private readonly DatabaseContext _context;

        public ConvidadoController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Convidado
        public async Task<IActionResult> Index()
        {
            return View(await _context.Convidados.ToListAsync());
        }

        // GET: Convidado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidadoEntity = await _context.Convidados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (convidadoEntity == null)
            {
                return NotFound();
            }

            return View(convidadoEntity);
        }

        // GET: Convidado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Convidado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Cpf,DataNascimento,Observacoes,DataCadastro,DataAlteracao")] ConvidadoEntity convidadoEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(convidadoEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(convidadoEntity);
        }

        // GET: Convidado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidadoEntity = await _context.Convidados.FindAsync(id);
            if (convidadoEntity == null)
            {
                return NotFound();
            }
            return View(convidadoEntity);
        }

        // POST: Convidado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Cpf,DataNascimento,Observacoes,DataCadastro,DataAlteracao")] ConvidadoEntity convidadoEntity)
        {
            if (id != convidadoEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(convidadoEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConvidadoEntityExists(convidadoEntity.Id))
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
            return View(convidadoEntity);
        }

        // GET: Convidado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidadoEntity = await _context.Convidados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (convidadoEntity == null)
            {
                return NotFound();
            }

            return View(convidadoEntity);
        }

        // POST: Convidado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var convidadoEntity = await _context.Convidados.FindAsync(id);
            _context.Convidados.Remove(convidadoEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConvidadoEntityExists(int id)
        {
            return _context.Convidados.Any(e => e.Id == id);
        }
    }
}
