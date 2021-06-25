using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XPTOChallenge.Models;

namespace XPTOChallenge.Data
{
    public class XPTOChallengeContext : DbContext
    {
        public XPTOChallengeContext (DbContextOptions<XPTOChallengeContext> options)
            : base(options)
        {
        }

        public DbSet<XPTOChallenge.Models.OrdemServico> OrdemServico { get; set; }

        public DbSet<XPTOChallenge.Models.Cliente> Cliente { get; set; }
    }
}
