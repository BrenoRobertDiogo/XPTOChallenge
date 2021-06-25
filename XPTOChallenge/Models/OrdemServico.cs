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
        public OrdemServico(Cliente cliente, int id, string tituloServico, double valorServico, DateTime dataExecucao, string cPFPrestador, string nomePrestador)
        {
            this.Cliente = cliente;
            Id = id;
            this.tituloServico = tituloServico;
            this.valorServico = valorServico;
            this.dataExecucao = dataExecucao;
            CPFPrestador = cPFPrestador;
            this.nomePrestador = nomePrestador;
        }
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Display(Name = "Nº OS")]
        //[Editable(allowEdit:false)]
        public int Id { get; set; }
        [Display(Name ="Serviço")]
        public string tituloServico { get; set; }
        
        [DataType(DataType.Currency)]
        [Display(Name ="Preço serviço")]
        public double valorServico { get; set; }
        [Display(Name ="Data execução")]
        [DataType(DataType.Date)]
        public DateTime dataExecucao { get; set; }
        
        // Prestador de serviço
        [Display(Name ="CPF prestador")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Digite um CPF válido (11 digitos)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-###-###-##}")]
        public string CPFPrestador { get; set; }
        [Display(Name ="Nome prestador")]
        public string nomePrestador { get; set; }

    }
}
