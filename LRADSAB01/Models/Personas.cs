using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LRADSAB01.Models
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100), NotNull]
        public string Nombres { get; set; }

        [MaxLength(100), NotNull]
        public string Apellidos { get; set; }

        [NotNull]
        public DateTime FechaNac { get; set; }

        [Unique, NotNull]
        public String telefono { get; set; }

        public byte[] foto { get; set; }

    }
}
