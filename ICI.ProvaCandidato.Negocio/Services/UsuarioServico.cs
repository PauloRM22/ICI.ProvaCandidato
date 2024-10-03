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
    public class UsuarioServico
    {
        private ApplicationDbContext _context;
        private NoticiaTagServico _noticiaTagServico;

        
        public UsuarioServico(ApplicationDbContext context)
        {
            _context = context;
            _noticiaTagServico = new NoticiaTagServico(context);
        }
        public async Task<Usuario> EditUsuario(Usuario usuarios)
        {
            try
            {
                _context.Update(usuarios);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(usuarios.Id))
                {
                    throw new Exception("Usuario não encontrada!");
                }
                else
                {
                    throw new Exception("Usuario invalida!");
                }
            }

            return usuarios;
        }

        public bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        public async Task<bool> AddUsuario(Usuario usuarios)
        {
            _context.Add(usuarios);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Usuario> PesquisarUsuario(int? id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);

            return usuarios;
        }

        public async Task DeletarUsuario(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();
        }

        public async Task PesquisarUsuarioAsync(int idUsuario)
        {
            var usuariosDb = await _context.Usuarios.Where(t => t.Id == idUsuario ).FirstOrDefaultAsync();

            if (usuariosDb == null) throw new Exception("Usuario não encontrada");

            string errormsg = await _noticiaTagServico.PesquisarNoticiaTagAsync(usuariosDb.Id);
        }        
    }
}
