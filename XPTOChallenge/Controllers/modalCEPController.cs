using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPTOChallenge.Data;

namespace XPTOChallenge.Controllers
{
    public class modalCEPController : Controller
    {
        private readonly XPTOChallengeContext _context;
        public modalCEPController(XPTOChallengeContext context)
        {
            _context = context;
        }
    }
}
