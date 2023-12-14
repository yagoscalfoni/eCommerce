using eCommerce.API.Database;
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
        private readonly eCommerceContext _db;
        public UsuarioRepository(eCommerceContext db)
        {
            _db = db;
        }
        public void Add(Usuario usuario)
        {
            /*
             * Unit of Works
             */

            _db.Usuarios.Add(usuario);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Usuarios.Remove(GetById(id));
            _db.SaveChanges();
        }

        public List<Usuario> Get()
        {
            return _db.Usuarios.OrderBy(x => x.Id).ToList();
        }

        public Usuario GetById(int id)
        {
            return _db.Usuarios.Find(id)!;
        }

        public void Update(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            _db.SaveChanges();
        }
    }
}
