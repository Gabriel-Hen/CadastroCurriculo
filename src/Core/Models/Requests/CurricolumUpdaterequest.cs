using Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Requests;
public class CurricolumUpdateRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Descricao é obrigatório")]
    public string Description { get; set; }
    public IEnumerable<CourseRequest> Courses { get; set; } = new List<CourseRequest>();
    public IEnumerable<ProfessionalExperienceRequest> ProfessionalExperiences { get; set; } = new List<ProfessionalExperienceRequest>();

    [Required(ErrorMessage = "Pretensao salarial é obrigatório")]
    public decimal SalaryExpectation { get; set; }

    [Required(ErrorMessage = "Nivel escolar é obrigatório")]
    public SchoolLevel SchoolLevel { get; set; }

    public string ProfessionalExperienceRemoved { get; set; }
    public string CoursesRemoved { get; set; }
}
