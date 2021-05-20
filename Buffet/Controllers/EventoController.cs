using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buffet.Data;
using Buffet.Models.Buffet.Evento;

namespace Buffet.Controllers
{
    public class EventoController : Controller
    {
        private readonly DatabaseContext _context;

        public EventoController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Evento
        public async Task<IActionResult> Index(string? descricao)
        {
            IQueryable<EventoEntity> eventos;
            eventos = descricao != null ? _context.Eventos.Where(c => c.Descricao.Contains(descricao)) : _context.Eventos.Include(e => e.Cliente).Include(e => e.Local).Include(e => e.SituacaoEvento).Include(e => e.TipoEvento);
            return View(await eventos.ToListAsync());
        }

        // GET: Evento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoEntity = await _context.Eventos
                .Include(e => e.Cliente)
                .Include(e => e.Local)
                .Include(e => e.SituacaoEvento)
                .Include(e => e.TipoEvento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventoEntity == null)
            {
                return NotFound();
            }

            return View(eventoEntity);
        }

        // GET: Evento/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome");
            ViewData["LocalEntityId"] = new SelectList(_context.Locais, "Id", "Descricao");
            ViewData["SituacaoEventoId"] = new SelectList(_context.SituacaoEvento, "Id", "Descricao");
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "Descricao");
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoEventoId,Descricao,HoraInicio,HoraTermino,ClienteId,SituacaoEventoId,LocalEntityId,Observacoes,DataCadastro,DataAlteracao")] EventoEntity eventoEntity)
        {
            if (ModelState.IsValid)
            {
                eventoEntity.DataAlteracao = DateTime.Now;
                eventoEntity.DataCadastro = DateTime.Now;
                _context.Add(eventoEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", eventoEntity.ClienteId);
            ViewData["LocalEntityId"] = new SelectList(_context.Locais, "Id", "Descricao", eventoEntity.LocalEntityId);
            ViewData["SituacaoEventoId"] = new SelectList(_context.SituacaoEvento, "Id", "Descricao", eventoEntity.SituacaoEventoId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "Descricao", eventoEntity.TipoEventoId);
            return View(eventoEntity);
        }

        // GET: Evento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoEntity = await _context.Eventos.FindAsync(id);
            if (eventoEntity == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", eventoEntity.ClienteId);
            ViewData["LocalEntityId"] = new SelectList(_context.Locais, "Id", "Descricao", eventoEntity.LocalEntityId);
            ViewData["SituacaoEventoId"] = new SelectList(_context.SituacaoEvento, "Id", "Descricao", eventoEntity.SituacaoEventoId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "Descricao", eventoEntity.TipoEventoId);
            return View(eventoEntity);
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoEventoId,Descricao,HoraInicio,HoraTermino,ClienteId,SituacaoEventoId,LocalEntityId,Observacoes,DataCadastro,DataAlteracao")] EventoEntity eventoEntity)
        {
            if (id != eventoEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    eventoEntity.DataAlteracao = DateTime.Now;
                    _context.Update(eventoEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoEntityExists(eventoEntity.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", eventoEntity.ClienteId);
            ViewData["LocalEntityId"] = new SelectList(_context.Locais, "Id", "Descricao", eventoEntity.LocalEntityId);
            ViewData["SituacaoEventoId"] = new SelectList(_context.SituacaoEvento, "Id", "Descricao", eventoEntity.SituacaoEventoId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "Descricao", eventoEntity.TipoEventoId);
            return View(eventoEntity);
        }

        // GET: Evento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoEntity = await _context.Eventos
                .Include(e => e.Cliente)
                .Include(e => e.Local)
                .Include(e => e.SituacaoEvento)
                .Include(e => e.TipoEvento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventoEntity == null)
            {
                return NotFound();
            }

            return View(eventoEntity);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventoEntity = await _context.Eventos.FindAsync(id);
            _context.Eventos.Remove(eventoEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoEntityExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
