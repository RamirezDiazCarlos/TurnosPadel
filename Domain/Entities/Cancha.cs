
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Cancha
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; }
        public List<Turno> Turnos { get; set; } = new List<Turno>();
    }
}

