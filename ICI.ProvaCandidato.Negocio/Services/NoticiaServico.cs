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
    public class NoticiaServico
    {
        private ApplicationDbContext _context;
        public NoticiaServico(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task AdicionarTagAsync(Noticia noticia, string tag, bool salvar = true)
        {
            if (noticia == null || noticia.Id < 1) throw new Exception("Noticia não encontrada");

            var tagDb = await _context.Tags.Where(t => t.Id.ToString() == tag).FirstOrDefaultAsync();            

            if (tagDb == null) throw new Exception("Tag não encontrada");

            _context.NoticiasTags.Add(new NoticiaTag { NoticiaId = noticia.Id, TagId = tagDb.Id });

            if(salvar)
                await _context.SaveChangesAsync();
        }

        public async Task AdicionarNoticiaComTagsAsync(Noticia noticia, string[] tags)
        {
            if (noticia == null || noticia.Id > 0) throw new Exception("Noticia invalida!");

            _context.Noticias.Add(noticia);

            await _context.SaveChangesAsync();

            foreach(var tag in tags)
            {
                await AdicionarTagAsync(noticia, tag, false);
            }

            await _context.SaveChangesAsync();
        }

        public async Task <Noticia> EditNoticia(Noticia noticia)
        {
            try
            {
                _context.Update(noticia);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiaExists(noticia.Id))
                {
                    throw new Exception("Noticia não encontrada!");
                }
                else
                {
                    throw new Exception("Noticia invalida!");
                }
            }

            return noticia;
        }

        private bool NoticiaExists(int id)
        {
            return _context.Noticias.Any(e => e.Id == id);
        }

        public async Task<Noticia> PesquisarNoticia(int? id)
        {
            var notocia = await _context.Noticias.FindAsync(id);

            return notocia;
        }

        public async Task<Noticia> PesquisarDetalhesNoticia(int? id)
        {
            var noticia = await _context.Noticias
                .Include(n => n.UsuarioFk)                
                .FirstOrDefaultAsync(m => m.Id == id);

            return noticia;
        }

        public async Task<Noticia> PesquisarDeleteNoticia(int? id)
        {
            var noticia = await _context.Noticias
                .Include(n => n.UsuarioFk)
                .FirstOrDefaultAsync(m => m.Id == id);

            return noticia;
        }

        public async Task DeletarNoticia(int id)
        {
            var noticia = await _context.Noticias.FindAsync(id);
            _context.Noticias.Remove(noticia);
            await _context.SaveChangesAsync();
        }
    }    
}
