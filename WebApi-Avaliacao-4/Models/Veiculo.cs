using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_Avaliacao_4.Models
{
    public class Veiculo
    {
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int AnoModelo { get; set; }

        [Required]
        public DateTime DataFabricacao { get; set; }

        [Required]
        public decimal Valor { get; set; }

        public string Opicionais { get; set; }
    }
}