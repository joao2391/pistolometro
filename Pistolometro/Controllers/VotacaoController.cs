﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pistolometro.Data;
using Pistolometro.Models;

namespace Pistolometro.Controllers
{
    [Authorize]
    public class VotacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VotacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Votacao
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Votacao
                                      .Include(v => v.IdentityUser)
                                      .ToListAsync());
        }

        // GET: Votacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votacao = await _context.Votacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (votacao == null)
            {
                return NotFound();
            }

            return View(votacao);
        }

        // GET: Votacao/Create
        public IActionResult Create()
        {
            ViewBag.UserId = _context.Users.Select(u => new SelectListItem() { Text = u.UserName, Value = u.Id});//new SelectList(_context.Users, "Id", "UserName");

            return View();
        }

        // POST: Votacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Inicio,Fim,QuantidadeVotos,IdUsuario")]Votacao votacao)
        {
            var x = _context.Users.Where(u => u.Id == votacao.IdUsuario).FirstOrDefault();//.Select(s => s.UserName);
            votacao.IdentityUser = x;
            //[Bind("Id,Inicio,Fim,QuantidadeVotos,NomeVencedor")]
            if (ModelState.IsValid)
            {
                _context.Add(votacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(votacao);
        }

        // GET: Votacao/Edit/5 
        public async Task<IActionResult> Edit(int id)
        {
            var votacao = await _context.Votacao.FindAsync(id);
            
            await Edit(id, votacao);

            return RedirectToAction("Index");
            
        }

        // POST: Votacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Inicio,Fim,QuantidadeVotos,NomeVencedor")] Votacao votacao)
        {
            if (id != votacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    votacao.QuantidadeVotos += 1;
                    _context.Update(votacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VotacaoExists(votacao.Id))
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
            return View(votacao);
        }

        // GET: Votacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votacao = await _context.Votacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (votacao == null)
            {
                return NotFound();
            }

            return View(votacao);
        }

        // POST: Votacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var votacao = await _context.Votacao.FindAsync(id);
            _context.Votacao.Remove(votacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VotacaoExists(int id)
        {
            return _context.Votacao.Any(e => e.Id == id);
        }
    }
}
