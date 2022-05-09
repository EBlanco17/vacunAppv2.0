using System.Collections.Generic;
using System.Linq;
using Utilitarios;

/// <summary>
/// Funciones que utiliza la aplicacion para guardar, editar, eliminar registro en la tabla solicitudAmd de la Base de Datos
/// </summary>

namespace Datos
{
    public class DAOSolicitudAdmin
    {
        public int verificarSolAdmin(int id)
        {
            return new Mapeo().solicitudAdmin.Where(x => x.UsuarioId == id).Count();
        }

        public void solicitarAdmin(ESolicitudAdministrador solAmd)
        {
            using (var db = new Mapeo())
            {
                db.solicitudAdmin.Add(solAmd); //add nuevo usuario
                db.SaveChanges();//confirmar el guardado
            }
        }

        public List<ESolicitudAdministrador> registros()
        {
            return new Mapeo().solicitudAdmin.OrderBy(x => x.FechaIngreso).ToList();
        }

        public void updateRol(EPersona user)
        {
            using (var db = new Mapeo())
            {
                var usuarioEditar = db.persona.FirstOrDefault(x => x.Id == user.Id);
                usuarioEditar.RolId = 1;
                db.SaveChanges();//confirmar el guardado
            }
        }

        public void deleteUserRol(int id)
        {
            using (var db = new Mapeo())
            {
                var itemToRemove = db.solicitudAdmin.SingleOrDefault(x => x.UsuarioId == id); //returns a single item.

                if (itemToRemove != null)
                {
                    db.solicitudAdmin.Remove(itemToRemove);
                    db.SaveChanges();
                }
            }
        }

        public ESolicitudAdministrador getSolicitudXId(int solicitudId)
        {
            using (var db = new Mapeo())
            {
                return db.solicitudAdmin.Where(x => x.Id == solicitudId).FirstOrDefault();
            }
        }
    }
}