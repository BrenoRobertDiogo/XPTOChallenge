using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XPTOChallenge.Models
{
    public class Cliente
    {
        [Display(Name = "CNPJ Cliente")]
        [DisplayFormat(DataFormatString = "{0:000\\.000\\.000-00}", ApplyFormatInEditMode = true)]
        [Range(10000000000000, 99999999999999, ErrorMessage = "Digite um valor válido de CNPJ (14 digitos)")]
        public long CNPJClient { get; set; }
        [Display(Name = "Nome Cliente")]
        public string nomeCliente { get; set; }
        [Range(10000000, 99999999, ErrorMessage = "Digite um valor válido de CEP (8 digitos)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#####-###}")]
        public int CEP { get; set; }
        public int Id { get; set; }
        public Cliente() { }
        public Cliente(string nomeCliente, long CNPJClient, int CEP, int Id)
        {
            this.nomeCliente = nomeCliente;
            this.CNPJClient = CNPJClient;
            this.CEP = CEP;
            this.Id = Id;
        }
    }
}
