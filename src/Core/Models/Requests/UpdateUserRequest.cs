using Core.Attributes.Validation;
using Core.Attributes;
using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Requests;
public class UpdateUserRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }

    public string Password { get; set; }

    [Compare(nameof(Password), ErrorMessage = "As senhas não são iguais")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Telefone é obrigatório")]
    public string Phone { get; set; }

    [Cpf, OnlyNumbers, Required(ErrorMessage = "Documento é obrigatório")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "Genero é obrigatório")]
    public Gender Gender { get; set; }
}
