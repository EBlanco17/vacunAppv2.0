﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("farmaceuticas", Schema = "administrativo")]
    public class EFarmaceutica
    {
        private int id;
        private string nombre;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
