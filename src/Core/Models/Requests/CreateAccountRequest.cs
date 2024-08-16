using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Requests;

public class CreateAccountRequest
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password é obrigatória")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirme sua senha")]
    [Compare(nameof(Password), ErrorMessage = "As senhas não são iguais")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Telefone é obrigatório")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Documento é obrigatório")]
    public string Document {  get; set; }

    [Required(ErrorMessage = "Genero é obrigatório")]
    public Gender Gender { get; set; }
}
