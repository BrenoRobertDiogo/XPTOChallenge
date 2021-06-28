using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XPTOChallenge.Data;
using XPTOChallenge.Models;
using XPTOChallenge.Models.ViewModel;
using XPTOChallenge.Services;

namespace XPTOChallenge.Controllers
{
    public class OrdemServicoesController : Controller
    {
        private readonly XPTOChallengeContext _context;
        private readonly OrdemServicoService _ordemService;

        public OrdemServicoesController(XPTOChallengeContext context, OrdemServicoService ordemServicoService)
        {
            _context = context;
            _ordemService = ordemServicoService;
        }

        // GET: OrdemServicoes
        public async Task<IActionResult> Index()
        {
            // _ordemService.FindAll();
            _context.Cliente.OrderBy(x => x.nomeCliente).ToList();
            var ordens = await _context.OrdemServico.ToListAsync();

            return View(ordens);
        }

        // GET: OrdemServicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            _context.Cliente.OrderBy(x => x.nomeCliente).ToList();
            if (id == null)
            {
                return NotFound();
            }

            var ordemServico = await _context.OrdemServico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordemServico == null)
            {
                return NotFound();
            }

            return View(ordemServico);
        }

        // GET: OrdemServicoes/Create
        public IActionResult Create()
        {
            var clientes = _ordemService.FindAll();
            var viewModel = new OrdemServiceViewModel(clientes);
            
            return View(viewModel);
        }

        // POST: OrdemServicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordemServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            _context.Cliente.OrderBy(x => x.nomeCliente).ToList();
            return View(ordemServico);
        }

        // GET: OrdemServicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            _context.Cliente.OrderBy(x => x.nomeCliente).ToList();
            if (id == null)
            {
                return NotFound();
            }

            var ordemServico = await _context.OrdemServico.FindAsync(id.Value);
            if (ordemServico == null)
            {
                return NotFound();
            }
            return View(ordemServico);
        }

        // POST: OrdemServicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("++++++++++++++++++++++++++PASSOU++++++++++++++\n" + id + " " + ordemServico.Id + "\n++++++++++++++++++++++++++++++++++++++++");

                try
                {
                    Console.WriteLine("++++++++++++++++++++++++++UPDATE COMPLETE++++++++++++++");
                    _context.Update(ordemServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdemServicoExists(ordemServico.Id))
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
            if (id != ordemServico.Id)
            {
                Console.WriteLine("++++++++++++++++++ERROR++++++++++++++++++++++\n" + id + " " + ordemServico.Id + "\n++++++++++++++++++++++++++++++++++++++++");
                return RedirectToAction(nameof(Index));
            }
            
            return View(ordemServico);
        }
        
        // GET: OrdemServicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemServico = await _context.OrdemServico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordemServico == null)
            {
                return NotFound();
            }

            return View(ordemServico);
        }

        // POST: OrdemServicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordemServico = await _context.OrdemServico.FindAsync(id);
            _context.OrdemServico.Remove(ordemServico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdemServicoExists(int id)
        {
            return _context.OrdemServico.Any(e => e.Id == id);
        }
    }
}
