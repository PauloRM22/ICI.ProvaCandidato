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
    public class TagServico
    {
        private ApplicationDbContext _context;
        private NoticiaTagServico _NoticiaTagServico;

        
        public TagServico(ApplicationDbContext context)
        {
            _context = context;
            _NoticiaTagServico = new NoticiaTagServico(context);
        }
        public async Task<Tag> EditTag(Tag tag)
        {
            try
            {
                _context.Update(tag);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(tag.Id))
                {
                    throw new Exception("Tag não encontrada!");
                }
                else
                {
                    throw new Exception("Tag invalida!");
                }
            }

            return tag;
        }

        public bool TagExists(int id)
        {
            return _context.Tags.Any(e => e.Id == id);
        }

        public async Task<bool> AddTag(Tag tag)
        {
            _context.Add(tag);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Tag> PesquisarTag(int? id)
        {
            var tag = await _context.Tags.FindAsync(id);

            return tag;
        }

        public async Task DeletarTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }

        public async Task<string> PesquisarTagAsync(int idTag)
        {
            var tagDb = await _context.Tags.Where(t => t.Id == idTag ).FirstOrDefaultAsync();

            if (tagDb == null) throw new Exception("Tag não encontrada");

            string errormsg = await _NoticiaTagServico.PesquisarNoticiaTagAsync(tagDb.Id);
            return errormsg;
        }        
    }
}
