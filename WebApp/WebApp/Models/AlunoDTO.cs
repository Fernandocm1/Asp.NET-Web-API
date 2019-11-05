using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class AlunoDTO
    {
       
        public int id { get; set; }

        [Required(ErrorMessage = "O nome é de Prenchimento Obrigatório!")]
        [StringLength(50, ErrorMessage ="Nome tem no mínimo 2 caracteres e no máximo 50", MinimumLength = 2)]

        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string telefone { get; set; }
        public string data { get; set; }

        [RegularExpression(@"[0-9]{4}\-[0-9]{2}", ErrorMessage = "A data esta fora do formato YYYY-MM")]
        [Required(ErrorMessage = "O RA é de Prenchimento Obrigatório!")]
        [Range(1,9099,ErrorMessage = "O intervalo para cadastro de RA está entre 1 e 9099")]
        public int? ra { get; set; }
    }
}