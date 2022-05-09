using System.Collections.Generic;
using System.Linq;
using Utilitarios;

namespace Datos
{
    public class DAOFormulario
    {
        public List<ELocalidad> listar()
        {
            return new Mapeo().localidad.ToList();
        }

        public List<EBarrio> listarBarrios(int idLocalidad)
        {
            return new Mapeo().barrio.Where(x => x.LocalidadId == idLocalidad).ToList();
        }

        public EFormulario verificarFormXUsuario(int id)
        {
            return new Mapeo().formulario.Where(x => x.UsuarioId == id).FirstOrDefault();
        }
        public void guardar(EFormulario formulario)
        {
            using (var db = new Mapeo())
            {
                db.formulario.Add(formulario); //add nuevo usuario
                db.SaveChanges();//confirmar el guardado
            }
        }

        public string getLocalidadXId(int id)
        {
            return new Mapeo().localidad.Where(x => x.Id.Equals(id)).Select(x => x.Nombre).ToString();
        }
        public string getBarrioXId(int id)
        {
            return new Mapeo().barrio.Where(x => x.Id.Equals(id)).Select(x => x.Nombre).ToString();
        }

        public EFormulario GetFormulario(int idUser)
        {
            return new Mapeo().formulario.Where(x => x.UsuarioId.Equals(idUser)).FirstOrDefault();
        }
    }
}