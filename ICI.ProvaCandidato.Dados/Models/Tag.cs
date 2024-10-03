using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Models
{
    public class Tag
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descricao")]
        [StringLength(100)]
        [Required(ErrorMessage = "* Campo descrição é obrigatório")]
        public string Descricao { get; set; }
    }
}
