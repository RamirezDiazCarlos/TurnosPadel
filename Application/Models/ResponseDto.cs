

namespace Application.Models
{
    public class ResponseDto
    {
        public string Token { get; set; }
        public string Rol { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public DateTime Expiration { get; set; }
    }
}
