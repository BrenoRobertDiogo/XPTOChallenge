using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XPTOChallenge.Models
{
    public class OrdemServico
    {
        public OrdemServico() { }
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


        [Display(Name = "Nº OS")]
        //[Editable(allowEdit:false)]
        public int Id { get; set; }
        [Display(Name ="Serviço")]
        public string tituloServico { get; set; }
        [Display(Name ="Nome cliente")]
        public string nomeCliente { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name ="Preço serviço")]
        public double valorServico { get; set; }
        [Display(Name ="Data execução")]
        [DataType(DataType.Date)]
        public DateTime dataExecucao { get; set; }
        [Display(Name ="CNPJ cliente")]
        [StringLength(14, MinimumLength =14, ErrorMessage ="Digite um CNPJ válido (14 digitos)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:##.###.###/####-##}")]
        public string CNPJClient { get; set; }
        // Prestador de serviço
        [Display(Name ="CPF prestador")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Digite um CPF válido (11 digitos)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-###-###-##}")]
        public string CPFPrestador { get; set; }
        [Display(Name ="Nome prestador")]
        public string nomePrestador { get; set; }

    }
}
