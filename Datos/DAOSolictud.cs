using System.Collections.Generic;
using System.Linq;
using Utilitarios;
/// <summary>
/// Funciones que utiliza la aplicacion para guardar, editar, eliminar registros en la tabla solicitudes de la Base de Datos
/// </summary>
namespace Datos
{
    public class DAOSolicitud
    {
        public ESolicitud insertarSolicitud(ESolicitud solicitud)
        {
            using (var db = new Mapeo())
            {
                db.solicitud.Add(solicitud);
                db.SaveChanges();

                return solicitud;
            }
        }

        public List<ESolicitud> registros()
        {
            return new Mapeo().solicitud.Where(x => x.Estado.Equals("SIN RESPONDER")).OrderBy(x => x.FechaIngreso).ToList();
        }

        public ESolicitud getSolicitudXId(int solicitudId)
        {
            using (var db = new Mapeo())
            {
                return db.solicitud.Where(x => x.Id == solicitudId).FirstOrDefault();
            }
        }

        public void updateSolicitud(ESolicitud eSolicitud)
        {
            using (var db = new Mapeo())
            {
                var solicitudEditar = db.solicitud.FirstOrDefault(x => x.Id == eSolicitud.Id);
                solicitudEditar.Estado = eSolicitud.Estado;
                solicitudEditar.FechaRespuesta = eSolicitud.FechaRespuesta;
                db.SaveChanges();//confirmar el guardado

            }
        }

    }
}