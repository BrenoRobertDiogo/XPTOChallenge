using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPTOChallenge.Data;
using XPTOChallenge.Models;

namespace XPTOChallenge.Services
{
    public class ClienteService
    {
        private readonly XPTOChallengeContext _context;
        public ClienteService(XPTOChallengeContext context)
        {
            _context = context;
        }
        public List<Cliente> FindAll()
        {
            return _context.Cliente.OrderBy(x => x.nomeCliente).ToList();
        }
    }
}
