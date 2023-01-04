using System.ComponentModel.DataAnnotations;

namespace Login.Data.DTO
{
    public class CreateUsuarioDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Compare("Email")]
        [Required]
        public string ReEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Compare("Senha")]
        [Required]
        public string ReSenha { get; set; }
    }
}
