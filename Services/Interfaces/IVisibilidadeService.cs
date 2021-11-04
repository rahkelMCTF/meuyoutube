using System.Collections.Generic;
using meuyoutube.Models;

namespace meuyoutube.Services.Interfaces
{
    public interface IVisibilidadeService
    {
        Visibilidade GetById(int id);
        List<Visibilidade> GetAll();
        bool Cadastrar(Visibilidade visibilidade);
        bool Atualizar(Visibilidade visibilidade);
    }
}