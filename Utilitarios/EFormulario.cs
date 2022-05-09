using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("formulario", Schema = "administrativo")]
    public class EFormulario
    {
        private int id;
        private int usuarioId;
        private string eps;
        private int localidadId;
        private int barrioId;
        private string direccion;
        private DateTime fechaRegistro;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("usuario_id")]
        public int UsuarioId { get => usuarioId; set => usuarioId = value; }
        [Column("eps")]
        public string Eps { get => eps; set => eps = value; }
        [Column("localidad_id")]
        public int LocalidadId { get => localidadId; set => localidadId = value; }
        [Column("barrio_id")]
        public int BarrioId { get => barrioId; set => barrioId = value; }
        [Column("direccion")]
        public string Direccion { get => direccion; set => direccion = value; }
        [Column("fecha_registro")]
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
    }
}
