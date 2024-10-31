
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BloqueReserva { get; set; }
        public string Horario { get; set; }
        public int Cupo { get; set; }
        public bool Disponible { get; set; }
        public int CanchaId { get; set; }
        public Cancha Cancha { get; set; }
    }
}
