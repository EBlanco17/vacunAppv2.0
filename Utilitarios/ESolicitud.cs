using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{

    [Serializable]
    [Table("solicitudes", Schema = "administrativo")]
    public class ESolicitud
    {
        private int id;
        private int usuarioId;
        private string tipoSolicitud;
        private DateTime fechaIngreso;
        private DateTime fechaLimite;
        private string mensaje;
        private string estado;
        private DateTime fechaRespuesta;
        private string respuesta;
        

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("usuario_id")]
        public int UsuarioId { get => usuarioId; set => usuarioId = value; }
        [Column("tipo_solicitud")]
        public string TipoSolicitud { get => tipoSolicitud; set => tipoSolicitud = value; }
        [Column("fecha_ingreso")]
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        [Column("mensaje")]
        public string Mensaje { get => mensaje; set => mensaje = value; }
        [Column("fecha_limite")]
        public DateTime FechaLimite { get => fechaLimite; set => fechaLimite = value; }
        [Column("estado")]
        public string Estado { get => estado; set => estado = value; }
        [Column("fecha_respuesta")]
        public DateTime FechaRespuesta { get => fechaRespuesta; set => fechaRespuesta = value; }
        [Column("respuesta")]
        public string Respuesta { get => respuesta; set => respuesta = value; }
        
    }
}