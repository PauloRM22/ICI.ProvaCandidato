using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Models
{
    public class Usuario
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        [StringLength(250)]
        [Required(ErrorMessage = "* Campo nome é obrigatório")]
        public string Nome { get; set; }

        [Column("Senha")]
        [Display(Name = "Senha")]
        [StringLength(50)]
        [Required(ErrorMessage = "* Campo senha é obrigatório")]
        public string Senha { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        [StringLength(250)]
        [Required(ErrorMessage = "* Campo email é obrigatório")]
        public string Email { get; set; }
    }
}
