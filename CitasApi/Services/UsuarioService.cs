using CitasApi.Models;
using CitasApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        // Base de datos
        private CitasMedicasContext CMContext;

        public UsuarioService(CitasMedicasContext cmcontext)
        {
            CMContext = cmcontext;
        }

        public void DeleteById(long id)
        {
            Usuario aux = FindById(id);
            if (aux != null)
            {
                CMContext.Usuarios.Remove(aux);
                CMContext.SaveChanges();
            }
        }

        public ICollection<Usuario> FindAll()
        {
            return CMContext.Usuarios.ToList<Usuario>();
        }

        public Usuario FindById(long id)
        {
            return CMContext.Usuarios.Find(id);
        }

        public bool Save(Usuario usuario)
        {
            if(usuario is not null)
            {
                CMContext.Usuarios.Add(usuario);
                CMContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
