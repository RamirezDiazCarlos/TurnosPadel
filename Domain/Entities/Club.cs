
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Club
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CVU { get; set; }
        public string Email { get; set; }
        public int NumeroDeCanchas { get; set; }
        public List<Cancha> Canchas { get; set; } = new List<Cancha>();
    }
}

