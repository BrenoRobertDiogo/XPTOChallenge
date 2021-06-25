using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPTOChallenge.Data;
using XPTOChallenge.Models;

namespace XPTOChallenge.Services
{
    public class OrdemServicoService
    {
        private readonly XPTOChallengeContext _context;
        public OrdemServicoService(XPTOChallengeContext context)
        {
            _context = context;
        }
        public List<Cliente> FindAll()
        {
            var teste = _context.Cliente.OrderBy(x => x.nomeCliente).ToList();
            return teste;
        }
    }
}
