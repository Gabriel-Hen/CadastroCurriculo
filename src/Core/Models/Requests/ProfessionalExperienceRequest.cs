using System;

namespace Core.Models.Requests;
public class ProfessionalExperienceRequest
{
    public string Role { get; set; }
    public string Description { get; set; }
    public string CompanyName { get; set; }
    public DateOnly InitialDate { get; set; }
    public DateOnly EndDate { get; set; }
}
