using System.ComponentModel.DataAnnotations;

namespace Core.Models.Requests;

public class AuthenticationRequest
{
    [Required(ErrorMessage = "E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password é obrigatória")]
    public string Password { get; set; }
    public bool KeepLoggedIn { get; set; }
}
