
using System.Collections.Generic;

namespace XPTOChallenge.Models.ViewModel
{
    public class OrdemServiceViewModel
    {
        public OrdemServiceViewModel(List<Cliente> listClients)
        {
            this.Clients = listClients;
        }
        public OrdemServico ordemServico { get; set; }
        public List<Cliente> Clients { get; set; }
    }
}
