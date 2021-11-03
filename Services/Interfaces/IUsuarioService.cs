using System.Collections.Generic;
using meuyoutube.Models;

namespace meuyoutube.Services.Interfaces
{
    public interface IUsuarioService
    {
        Usuario GetUsuario(string username);
    }
}