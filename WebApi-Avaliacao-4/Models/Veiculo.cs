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
        [StringLength(50)]
        public string Marca { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public int AnoModelo { get; set; }

        [Required]
        public DateTime DataFabricacao { get; set; }

        [Required]
        public decimal Valor { get; set; }
        
        [StringLength(500)]
        public string Opcionais { get; set; }
    }
}