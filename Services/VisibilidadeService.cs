using System;
using System.Collections.Generic;
using System.Linq;
using meuyoutube.Data;
using meuyoutube.Models;
using meuyoutube.Services.Interfaces;

namespace meuyoutube.Services
{
    public class VisibilidadeService : IVisibilidadeService
    {
        private readonly ApplicationDbContext _context;

        public VisibilidadeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Atualizar(Visibilidade visibilidade)
        {
            throw new NotImplementedException();
        }

        public bool Cadastrar(Visibilidade visibilidade)
        {
            throw new NotImplementedException();
        }

        public List<Visibilidade> GetAll()
        {
            try{
                return _context.Visibilidade.ToList();                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return new List<Visibilidade>();
        }

        public Visibilidade GetById(int id)
        {
            try{
                return _context.Visibilidade.SingleOrDefault(v => v.Id == id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return new Visibilidade();
        }
    }
}