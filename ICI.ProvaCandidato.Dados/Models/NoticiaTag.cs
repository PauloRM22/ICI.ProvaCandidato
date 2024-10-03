using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Models
{
    public class NoticiaTag
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("NoticiaId")]
        [Display(Name = "NoticiaId")]
        public int NoticiaId { get; set; }

        [ForeignKey("NoticiaId")]
        public virtual Noticia NoticiaFk { get; set; }

        [Column("TagId")]
        [Display(Name = "TagId")]
        public int TagId { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag TagFk { get; set; }
    }
}
