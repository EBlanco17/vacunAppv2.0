using System;
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
                vacunaEditar.Cantidad = vacuna.Cantidad;
                db.SaveChanges();//confirmar el guardado
            }
        }

        public List<EVacuna> registros(int idFarm)
        {
            return new Mapeo().vaccine.Where(x=> x.Farmaceutica_id.Equals(idFarm) && x.Cantidad > 0).ToList();
        }


        public List<EVacuna> registrosVacunas()
        {
            using (var db = new Mapeo())
            {
                return (from v in db.vaccine
                        join f in db.farmaceutica on v.Farmaceutica_id equals f.Id

                        select new
                        {
                            v,
                            f
                        }).ToList().Select(x => new EVacuna
                        {
                            Id = x.v.Id,
                            Nombre_farmaceutica = x.f.Nombre,
                            Nombre = x.v.Nombre,
                            Lote = x.v.Lote,
                            FechaFabricacion = x.v.FechaFabricacion,
                            FechaExpiracion = x.v.FechaExpiracion,
                            Cantidad = x.v.Cantidad
                        }).OrderBy(i=> i.Id).ToList();

            }
        }

        public EVacuna verVacunaXId(int id)
        {
            using (var db = new Mapeo())
            {
                return (from v in db.vaccine
                        join f in db.farmaceutica on v.Farmaceutica_id equals f.Id
                        
                        select new
                        {
                            v,
                            f
                        }).ToList().Select(x => new EVacuna
                        {
                            Id = x.v.Id,
                            Nombre_farmaceutica = x.f.Nombre,
                            Nombre = x.v.Nombre,
                            Lote = x.v.Lote,
                            FechaFabricacion = x.v.FechaFabricacion,
                            FechaExpiracion = x.v.FechaExpiracion,
                            Cantidad = x.v.Cantidad,
                            NoDosis = x.v.NoDosis,
                            Descripcion = x.v.Descripcion,
                            TiempoProteccion = x.v.TiempoProteccion,
                            Farmaceutica_id = x.v.Farmaceutica_id
                            
                        }).Where(y => y.Id == id).FirstOrDefault();

            }
        }

        //*****************************************************************

        public int getDosisTotales(int id)
        {
            return new Mapeo().vaccine.Where(x => x.Id == id).Select(v => v.NoDosis).FirstOrDefault();
        }

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
                        join v in db.vaccine on va.VacunaId equals v.Id
                        join p in db.persona on va.UsuarioId equals p.Id
                        join f in db.farmaceutica on v.Farmaceutica_id equals f.Id
                        
                                                
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
