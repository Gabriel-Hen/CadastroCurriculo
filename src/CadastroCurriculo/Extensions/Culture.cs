using System.Globalization;

namespace CadastroCurriculo.Extensions;

public class Culture
{
    public static CultureInfo GetPtBr()
    {
        var portugues = new CultureInfo("pt-br");
        portugues.NumberFormat.CurrencyGroupSeparator = "."; //1x123x,10
        portugues.NumberFormat.CurrencyDecimalSeparator = ","; //1.500x10
        portugues.NumberFormat.NumberDecimalSeparator = ",";
        portugues.NumberFormat.NumberGroupSeparator = ".";
        portugues.NumberFormat.PercentDecimalSeparator = ",";
        portugues.NumberFormat.PercentGroupSeparator = ".";
        portugues.NumberFormat.NumberDecimalDigits = 2;
        portugues.NumberFormat.PercentDecimalDigits = 2;

        portugues.DateTimeFormat.DateSeparator = "/";
        portugues.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
        portugues.DateTimeFormat.AbbreviatedDayNames = new string[] {
            "dom.",
            "seg.",
            "ter.",
            "qua.",
            "qui.",
            "sex.",
            "sáb."
        };

        portugues.DateTimeFormat.ShortestDayNames = new string[]
        {
            "domingo",
            "segunda-feira",
            "terça-feira",
            "quarta-feira",
            "quinta-feira",
            "sexta-feira",
            "sábado"
        };

        portugues.DateTimeFormat.AbbreviatedMonthNames = new string[] {
            "jan.",
            "fev.",
            "mar.",
            "abr.",
            "mai.",
            "jun.",
            "jul.",
            "ago.",
            "set.",
            "out.",
            "nov.",
            "dez.",
            ""
        };

        portugues.DateTimeFormat.MonthNames = new string[] {
            "janeiro",
            "fevereiro",
            "março",
            "abril",
            "maio",
            "junho",
            "julho",
            "agosto",
            "setembro",
            "outubro",
            "novembro",
            "dezembro",
            ""
        };

        portugues.DateTimeFormat.AbbreviatedMonthGenitiveNames = new string[] {
            "jan.",
            "fev.",
            "mar.",
            "abr.",
            "mai.",
            "jun.",
            "jul.",
            "ago.",
            "set.",
            "out.",
            "nov.",
            "dez.",
            ""
        };

        portugues.DateTimeFormat.MonthGenitiveNames = new string[]
        {
            "janeiro",
            "fevereiro",
            "março",
            "abril",
            "maio",
            "junho",
            "julho",
            "agosto",
            "setembro",
            "outubro",
            "novembro",
            "dezembro",
            ""
        };

        return portugues;
    }
}
