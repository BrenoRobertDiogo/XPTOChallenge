using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Refit;
using XPTOChallenge.Data;
using XPTOChallenge.Models;
using XPTOChallenge.Models.ViewModel;
using XPTOChallenge.Services;

namespace XPTOChallenge.Controllers
{
    public class ClientesController : Controller
    {
        private readonly XPTOChallengeContext _context;
        //private readonly ClienteService _clientesService;

        public ClientesController(XPTOChallengeContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
            var address = await cepClient.GetAddressAsync(cliente.CEP.ToString());
            if (cliente.nomeCliente == "Nicolas Cage")
            {
                string aviso = "Cage's area";
                ViewData["logradouro"] = aviso;
                ViewData["bairro"]     = aviso;
                ViewData["localidade"] = aviso;
            } else if (address.Logradouro != null && address.Bairro != null && address.Localidade != null)
            {
                ViewData["logradouro"] = address.Logradouro;
                ViewData["bairro"]     = address.Bairro;
                ViewData["localidade"] = address.Localidade;

            } else
            {
                string mensagem = "Não encontrado";
                ViewData["logradouro"] = mensagem;
                ViewData["bairro"]     = mensagem;
                ViewData["localidade"] = mensagem;
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CNPJClient,nomeCliente,CEP,Id")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CNPJClient,nomeCliente,CEP,Id")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        public async Task<IActionResult> modalCEP(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
            var address = await cepClient.GetAddressAsync(cliente.CEP.ToString());
            if (cliente.nomeCliente == "Nicolas Cage")
            {
                string aviso = "Cage's area";
                ViewData["logradouro"] = aviso;
                ViewData["bairro"] = aviso;
                ViewData["localidade"] = aviso;
            }
            else if (address.Logradouro != null && address.Bairro != null && address.Localidade != null)
            {
                string dado = "Não encontrado";
                ViewData["logradouro"]  = address.Logradouro. Equals("") || address. Logradouro != null ? address.Logradouro  : dado;
                ViewData["bairro"]      = address.     Bairro.Equals("") || address.     Bairro != null ? address.     Bairro : dado;
                ViewData["localidade"]  = address. Localidade.Equals("") || address. Localidade != null ? address. Localidade : dado;
                ViewData["complemento"] = address.Complemento.Equals("") || address.Complemento != null ? address.Complemento : dado;
                ViewData["gia"]         = address.        Gia.Equals("") || address.        Gia != null ? address.        Gia : dado;
                ViewData["uf"]          = address.         Uf.Equals("") || address.         Uf != null ? address.         Uf : dado;
                //ViewData["unidade"]     = address.    Unidade.Equals("") || address.    Unidade != null ? address.    Unidade : dado;

            }
            else
            {
                string mensagem = "Não encontrado";
                ViewData["logradouro"] = mensagem;
                ViewData["bairro"] = mensagem;
                ViewData["localidade"] = mensagem;
            }
            return PartialView(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}
