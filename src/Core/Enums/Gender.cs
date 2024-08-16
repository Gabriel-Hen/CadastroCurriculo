using System.ComponentModel.DataAnnotations;

namespace Core.Enums;
public enum Gender
{
    [Display(Name = "Feminino")]
    Femele,
    [Display(Name = "Masculino")]
    Male,
    [Display(Name = "Outro")]
    Other
}
