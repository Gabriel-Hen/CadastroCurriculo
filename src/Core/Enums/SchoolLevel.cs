using System.ComponentModel.DataAnnotations;

namespace Core.Enums;
public enum SchoolLevel
{
    [Display(Name = "Fundamenta incompleto")]
    IncompleteMiddleSchool,
    [Display(Name = "Fundamenal completo")]
    CompleteMiddleSchool,
    [Display(Name = "Ensino medo incompleto")]
    IncompleteHighSchool,
    [Display(Name = "Ensino medio completo")]
    CompleteHighSchool,
    [Display(Name = "Superior incompleto")]
    IncompleteCollege,
    [Display(Name = "Superior completo")]
    CompleteCollege,
}
