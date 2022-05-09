using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("vacunasaplicadas", Schema = "administrativo")]
    public class EVacunasAplicadas
    {
        private int id;
        private int usuarioId;
        private int vacunaId;
        private DateTime fechaAplicacion;
        private int noDosis;
        private string lugarAplicacion;
        private string farmaceutica;
        private string vacuna;
        private string descripcion;
        private int noDosisTotales;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("usuario_id")]
        public int UsuarioId { get => usuarioId; set => usuarioId = value; }
        [Column("vacuna_id")]
        public int VacunaId { get => vacunaId; set => vacunaId = value; }
        [Column("fecha_aplicacion")]
        public DateTime FechaAplicacion { get => fechaAplicacion; set => fechaAplicacion = value; }
        [Column("no_dosis")]
        public int NoDosis { get => noDosis; set => noDosis = value; }
        [Column("lugar_aplicacion")]
        public string LugarAplicacion { get => lugarAplicacion; set => lugarAplicacion = value; }
        [NotMapped]
        public string Farmaceutica { get => farmaceutica; set => farmaceutica = value; }
        [NotMapped]
        public string Vacuna { get => vacuna; set => vacuna = value; }
        [NotMapped]
        public string Descripcion { get => descripcion; set => descripcion = value; }
        [NotMapped]
        public int NoDosisTotales { get => noDosisTotales; set => noDosisTotales = value; }
    }
}
