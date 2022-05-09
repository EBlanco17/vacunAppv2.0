using System.Linq;
using Utilitarios;

namespace Datos
{
    public class DAOUsuario
    {

        public int comprobarBD(string correo)
        {
            return new Mapeo().persona.Where(x => x.Correo.Equals(correo)).Count();
        }
        public int comprobarDocumentos(string documento)
        {
            return new Mapeo().persona.Where(x => x.Documento.Equals(documento)).Count();
        }

        public EPersona correoRegistrado(string documento)
        {
            return new Mapeo().persona.Where(x => x.Documento.Equals(documento)).FirstOrDefault();
        }
        public EPersona login(EPersona user)
        {
            return new Mapeo().persona.Where(x => x.Correo.Equals(user.Correo) && x.Clave.Equals(user.Clave) && x.RolId.Equals(user.RolId)).FirstOrDefault();
        }

        public void createUser(EPersona user)
        {
            using (var db = new Mapeo())
            {
                db.persona.Add(user); //add nuevo usuario
                db.SaveChanges();//confirmar el guardado
            }
        }

        public EPersona recuperarPassword(string correo)
        {
            return new Mapeo().persona.Where(x => x.Correo.Equals(correo)).FirstOrDefault();
        }

        public void updateUser(EPersona user)
        {
            using (var db = new Mapeo())
            {
                var usuarioEditar = db.persona.FirstOrDefault(x => x.Id == user.Id);
                usuarioEditar.Nombres = user.Nombres;
                usuarioEditar.Apellidos = user.Apellidos;
                usuarioEditar.Documento = user.Documento;
                usuarioEditar.Telefono = user.Telefono;
                usuarioEditar.Correo = user.Correo;
                db.SaveChanges();//confirmar el guardado
            }
        }

        public void updatePassword(EPersona user)
        {
            using (var db = new Mapeo())
            {
                var usuarioEditar = db.persona.FirstOrDefault(x => x.Id == user.Id);
                usuarioEditar.Clave = user.Clave;
                db.SaveChanges();//confirmar el guardado

            }
        }

        public EPersona getUsuarioXId(int id)
        {
            return new Mapeo().persona.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
