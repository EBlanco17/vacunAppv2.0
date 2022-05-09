using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("vacunas", Schema = "administrativo")]
    public class EVacuna
    {
        private int id;
        private int farmaceutica_id;
        private string nombre;
        private string lote;
        private DateTime fechaFabricacion;
        private DateTime fechaExpiracion;
        private int tiempoProteccion;
        private string descripcion;
        private int cantidad;
        private int noDosis;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("farmaceutica_id")]
        public int Farmaceutica_id { get => farmaceutica_id; set => farmaceutica_id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("lote")]
        public string Lote { get => lote; set => lote = value; }
        [Column("fecha_fabricacion")]
        public DateTime FechaFabricacion { get => fechaFabricacion; set => fechaFabricacion = value; }
        [Column("fecha_expiracion")]
        public DateTime FechaExpiracion { get => fechaExpiracion; set => fechaExpiracion = value; }
        [Column("tiempo_proteccion")]
        public int TiempoProteccion { get => tiempoProteccion; set => tiempoProteccion = value; }
        [Column("descripcion")]
        public string Descripcion { get => descripcion; set => descripcion = value; }
        [Column("cantidad")]
        public int Cantidad { get => cantidad; set => cantidad = value; }
        [Column("no_dosis")]
        public int NoDosis { get => noDosis; set => noDosis = value; }

        


    }
}
