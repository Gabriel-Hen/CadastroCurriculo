using Core.Enums;
using System.Collections.Generic;

namespace Core.Models.Requests;
public class CurricolumRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<CourseRequest> Courses { get; set; }
    public IEnumerable<ProfessionalExperienceRequest> ProfessionalExperiences { get; set; }
    public decimal SalaryExpectation { get; set; }
    public SchoolLevel SchoolLevel { get; set; }
}
