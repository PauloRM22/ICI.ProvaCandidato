using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Models
{
    public class Noticia
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Titulo")]
        [Display(Name = "Titulo")]
        [StringLength(250)]
        [Required(ErrorMessage = "* Campo titulo é obrigatório")]
        public string Titulo { get; set; }


        [Column("Text", TypeName = "text")]
        [Display(Name = "Texto")]
        [Required(ErrorMessage = "* Campo texto é obrigatório")]
        public string Text { get; set; }

        [Column("UsuarioId")]
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "* Campo usuario é obrigatório")]
        public int UsuarioId { get; set; }       

        [ForeignKey("UsuarioId")]
        [Display(Name = "Usuario")]
        public virtual Usuario UsuarioFk { get; set; }

        public ICollection<NoticiaTag> NoticiasTags { get; set; }
    }
}
