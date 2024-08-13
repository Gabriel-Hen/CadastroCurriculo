namespace Core.Attributes.Validations;
public class CpfValidation
{
    public static bool Cpf(string value)
    {
        int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        var cpf = value.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
            return false;
        var tempCpf = cpf[..9];
        var sum = 0;

        for (int i = 0; i < 9; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
        var resto = sum % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        var digito = resto.ToString();
        tempCpf += digito;
        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
        resto = sum % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito += resto.ToString();
        return cpf.EndsWith(digito);
    }
}