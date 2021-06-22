using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XPTOChallenge.Models
{
    public class OrdemServico
    {
        // public OrdemServico() { }
        public OrdemServico(int id, string tituloServico, string nomeCliente, double valorServico, DateTime dataExecucao, string cNPJClient, string cPFPrestador, string nomePrestador)
        {
            Id = id;
            this.tituloServico = tituloServico;
            this.nomeCliente = nomeCliente;
            this.valorServico = valorServico;
            this.dataExecucao = dataExecucao;
            CNPJClient = cNPJClient;
            CPFPrestador = cPFPrestador;
            this.nomePrestador = nomePrestador;
        }

        public int Id { get; set; }
        public string tituloServico { get; set; }
        public string nomeCliente { get; set; }
        public double valorServico { get; set; }
        public DateTime dataExecucao { get; set; }
        public string CNPJClient { get; set; }
        // Prestador de serviço
        public string CPFPrestador { get; set; }
        public string nomePrestador { get; set; }

    }
}
