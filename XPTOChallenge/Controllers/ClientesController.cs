using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
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

            var cliente = await _context.Cliente.FindAsync(id.Value);
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
            CepResponse address = await cepClient.GetAddressAsync(cliente.CEP.ToString());
            if (cliente.nomeCliente == "Nicolas Cage")
            {
                string aviso = "Cage's area";
                ViewData["logradouro"] = aviso;
                ViewData["bairro"]     = aviso;
                ViewData["localidade"] = aviso;
            }
            else
            {
                string dado = "Não encontrado";
                char[] charsToTrim = { ' ' };
                ViewData["logradouro"]  = !string.IsNullOrWhiteSpace(address. Logradouro) || !string.IsNullOrEmpty(address. Logradouro ) ? address.Logradouro  : dado;
                ViewData["bairro"]      = !string.IsNullOrWhiteSpace(address.     Bairro) || !string.IsNullOrEmpty(address.     Bairro ) ? address.     Bairro : dado;
                ViewData["localidade"]  = !string.IsNullOrWhiteSpace(address. Localidade) || !string.IsNullOrEmpty(address. Localidade ) ? address. Localidade : dado;
                ViewData["complemento"] = !string.IsNullOrWhiteSpace(address.Complemento) || !string.IsNullOrEmpty(address.Complemento ) ? address.Complemento : dado;
                ViewData["gia"]         = !string.IsNullOrWhiteSpace(address.        Gia) || !string.IsNullOrEmpty(address.        Gia ) ? address.        Gia : dado;
                ViewData["uf"]          = !string.IsNullOrWhiteSpace(address.         Uf) || !string.IsNullOrEmpty(address.         Uf ) ? address.         Uf : dado;
                ViewData["unidade"]     = !string.IsNullOrWhiteSpace(address.    Unidade) || !string.IsNullOrEmpty(address.     Unidade) ? address.Uf : dado;
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
