using System.Collections.Generic;
using System.Linq;
using Utilitarios;

namespace Datos
{
    public class DAOVacuna
    {
        public List<EFarmaceutica> listarFarmaceuticas()
        {
            return new Mapeo().farmaceutica.ToList();
        }

        public void registrarVacuna(EVacuna vacunaA)
        {
            using (var db = new Mapeo())
            {
                db.vaccine.Add(vacunaA); //add nueva vacuna
                db.SaveChanges();//confirmar el guardado
            }
        }

        public void updateVacuna(EVacuna vacuna)
        {
            using (var db = new Mapeo())
            {
                var vacunaEditar = db.vaccine.FirstOrDefault(x => x.Id == vacuna.Id);
                vacunaEditar.Nombre = vacuna.Nombre;
                vacunaEditar.Descripcion = vacuna.Descripcion;
                vacunaEditar.NoDosis = vacuna.NoDosis;
                
                db.SaveChanges();//confirmar el guardado
            }
        }

        public List<EVacuna> registros(int idFarm)
        {
            return new Mapeo().vaccine.Where(x=> x.Farmaceutica_id.Equals(idFarm) && x.Cantidad > 0).ToList();
        }




        //*****************************************************************

        public void registrarVacunaAplicada(EVacunasAplicadas vacunaA)
        {
            using (var db = new Mapeo())
            {
                db.vacunaAplicada.Add(vacunaA); //add nueva vacuna
                db.SaveChanges();//confirmar el guardado
            }
        }

        public List<EVacunasAplicadas> verEsquema(int id)
        {
                 
            using (var db = new Mapeo())
            {
                return (from va in db.vacunaAplicada
                        from v in db.vaccine
                        join f in db.farmaceutica on v.Farmaceutica_id equals f.Id
                        join p in db.persona on va.UsuarioId equals p.Id
                                                
                        where p.Id == id
                        select new
                        {
                            va,
                            v,
                            f,
                            p
                        }).ToList().Select(x => new EVacunasAplicadas
                        {
                            Id = x.va.Id,
                            UsuarioId = x.p.Id,
                            VacunaId = x.va.Id,
                            FechaAplicacion = x.va.FechaAplicacion,
                            NoDosis = x.va.NoDosis,
                            LugarAplicacion = x.va.LugarAplicacion,
                            Farmaceutica = x.f.Nombre,
                            Vacuna = x.v.Nombre,
                            Descripcion = x.v.Descripcion,
                            NoDosisTotales = x.v.NoDosis

                        }).ToList();
            }
        }
    }
}
