using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buffet.Data;
using Buffet.Models.Buffet.Cliente;

namespace Buffet.Controllers
{
    public class ClienteController : Controller
    {
        private readonly DatabaseContext _context;

        public ClienteController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index(string? nome, string? cpf)
        {
            IQueryable<ClienteEntity> databaseContext;
            databaseContext = nome != null ? _context.Clientes.Where(c => c.Nome.Contains(nome)) : _context.Clientes.Include(c => c.TipoCliente);
            
            return View(await databaseContext.ToListAsync());
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEntity = await _context.Clientes
                .Include(c => c.TipoCliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteEntity == null)
            {
                return NotFound();
            }

            clienteEntity.Eventos = await _context.Eventos.Where(e => e.ClienteId.Equals(clienteEntity.Id)).ToListAsync();
            return View(clienteEntity);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            ViewData["TipoClienteId"] = new SelectList(_context.TipoCliente, "Id", "Descricao");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoClienteId,Cpf,DataNascimento,Cnpj,Nome,Email,Endereco,Observacoes,DataCadastro,DataAlteracao")] ClienteEntity clienteEntity)
        {
            if (ModelState.IsValid)
            {
                clienteEntity.DataCadastro = DateTime.Now;
                clienteEntity.DataAlteracao = DateTime.Now;
                _context.Add(clienteEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoClienteId"] = new SelectList(_context.TipoCliente, "Id", "Descricao", clienteEntity.TipoClienteId);
            return View(clienteEntity);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEntity = await _context.Clientes.FindAsync(id);
            if (clienteEntity == null)
            {
                return NotFound();
            }
            ViewData["TipoClienteId"] = new SelectList(_context.TipoCliente, "Id", "Descricao", clienteEntity.TipoClienteId);
            return View(clienteEntity);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoClienteId,Cpf,DataNascimento,Cnpj,Nome,Email,Endereco,Observacoes,DataCadastro,DataAlteracao")] ClienteEntity clienteEntity)
        {
            if (id != clienteEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    clienteEntity.DataAlteracao = DateTime.Now;
                    _context.Update(clienteEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteEntityExists(clienteEntity.Id))
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
            ViewData["TipoClienteId"] = new SelectList(_context.TipoCliente, "Id", "Descricao", clienteEntity.TipoClienteId);
            return View(clienteEntity);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEntity = await _context.Clientes
                .Include(c => c.TipoCliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteEntity == null)
            {
                return NotFound();
            }

            return View(clienteEntity);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteEntity = await _context.Clientes.FindAsync(id);
            var eventos = await _context.Eventos.Where(e => e.ClienteId.Equals(clienteEntity.Id)).ToListAsync();
            if (eventos.Count == 0)
            {
                _context.Clientes.Remove(clienteEntity);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteEntityExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
