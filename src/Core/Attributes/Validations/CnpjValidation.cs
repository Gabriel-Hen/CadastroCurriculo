using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Attributes.Validations;
public class CnpjValidation
{
    public static bool Cnpj(string value)
    {
        int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        var cnpj = value.Trim();
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
        if (cnpj.Length != 14)
            return false;
        var tempCnpj = cnpj[..12];
        var sum = 0;
        for (int i = 0; i < 12; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];
        var resto = sum % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        var digito = resto.ToString();
        tempCnpj += digito;
        sum = 0;
        for (int i = 0; i < 13; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];
        resto = sum % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito += resto.ToString();
        return cnpj.EndsWith(digito);
    }
}