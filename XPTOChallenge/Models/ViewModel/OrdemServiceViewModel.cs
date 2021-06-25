
using System.Collections.Generic;

namespace XPTOChallenge.Models.ViewModel
{
    public class OrdemServiceViewModel
    {
        public OrdemServico ordemServico { get; set; }
        public ICollection<Cliente> Clients { get; set; }
    }
}
