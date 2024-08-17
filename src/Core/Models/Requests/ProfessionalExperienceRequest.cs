using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Requests;
public class ProfessionalExperienceRequest
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Cargo é obrigatório")]
    public string Role { get; set; }

    [Required(ErrorMessage = "Descricao é obrigatório")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Empresa é obrigatório")]
    public string CompanyName { get; set; }

    [Required(ErrorMessage = "Data de inicio é obrigatório")]
    public DateOnly? InitialDate { get; set; }
    public DateOnly? EndDate { get; set; }
}
