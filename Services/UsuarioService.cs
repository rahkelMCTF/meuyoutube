using System;
using System.Linq;
using meuyoutube.Data;
using meuyoutube.Models;
using meuyoutube.Services.Interfaces;

namespace meuyoutube.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Usuario GetUsuario(string username)
        {
            try{
                return _context.Users.SingleOrDefault(u => u.UserName == username);
            }
            catch(Exception ex){
                Console.WriteLine(ex);
            }
            return new Usuario();
        }
    }
}