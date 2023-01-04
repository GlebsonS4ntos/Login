using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class Usuario
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
