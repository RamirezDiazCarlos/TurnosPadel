
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario Usuario { get; set; }
        public int CanchaId { get; set; }
        [JsonIgnore]
        public Cancha Cancha { get; set; }
        public int TurnoId { get; set; }
        [JsonIgnore]
        public Turno Turno { get; set; }
    }
}
