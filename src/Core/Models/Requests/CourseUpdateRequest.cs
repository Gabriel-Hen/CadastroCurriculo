using System.ComponentModel.DataAnnotations;
using System;

namespace Core.Models.Requests;
public class CourseUpdateRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Descricao é obrigatório")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Data de inicio é obrigatório")]
    public DateOnly InitialDate { get; set; }
    public DateOnly? EndDate { get; set; }
}
