using eCommerce.Models;
using System.Net.NetworkInformation;

namespace eCommerce.API.Repositories
{
    /*
     *  Controller > UsuarioRepository
     *  Controller > IUsuarioRepository(Abstrai) > UsuarioRepository (Implementa IUsuarioRepository)
     *  Controller > IUsuarioRepository > Usuario EFRepository (EF CORE)
     *  Controller > IUsuarioRepository > UsuarioMockRepository (Teste)
     */
    public class UsuarioRepository : IUsuarioRepository
    {
        public static List<Usuario> _db = new List<Usuario>();
        public void Add(Usuario usuario)
        {
            _db.Add(usuario);
        }

        public void Delete(int id)
        {
            _db.Remove(GetById(id));
        }

        public List<Usuario> Get()
        {
            return _db;
        }

        public Usuario GetById(int id)
        {
            return _db.Find(x => x.Id == id)!;
        }

        public void Update(Usuario usuario)
        {
            _db.Remove(GetById(usuario.Id));
            _db.Add(usuario);
        }
    }
}
