using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Dados.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services
{
    public class NoticiaTagServico
    {
        private ApplicationDbContext _context;        
        public NoticiaTagServico(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> PesquisarNoticiaTagAsync(int idTag)
        {
            var noticiaTagDb = await _context.NoticiasTags.Include(t => t.NoticiaFk).Include(t => t.TagFk).Where(t => t.TagId == idTag).FirstOrDefaultAsync();
            

            if (noticiaTagDb != null) return ("A Tag '" + noticiaTagDb.TagFk.Descricao + "' não pode ser excluída, pois ela foi usada na Noticia '" + noticiaTagDb.NoticiaFk.Titulo + "'");
            else return null;
        }
    }
}
