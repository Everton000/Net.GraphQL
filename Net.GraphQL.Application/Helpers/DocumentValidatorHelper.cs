using System.Text.RegularExpressions;

namespace Net.GraphQL.Application.Helpers;

public class DocumentValidatorHelper
{
    public static bool IsValidCPFCNPJ(string cpfCnpj)
    {
        if (Regex.Replace(cpfCnpj, @"\D", "").Length == 11)
        {
            return IsValidCPF(cpfCnpj);
        }
        else
        {
            return IsValidCNPJ(cpfCnpj);
        }
    }

    public static bool IsValidCPF(string cpf)
    {
        cpf = Regex.Replace(cpf, @"\D", "");

        if (cpf.Length != 11 || IsRepeatedDigits(cpf))
            return false;

        int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf.Substring(0, 9);
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        int digito1 = resto < 2 ? 0 : 11 - resto;

        tempCpf += digito1;
        soma = 0;

        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        return cpf.EndsWith(digito1.ToString() + digito2.ToString());
    }

    public static bool IsValidCNPJ(string cnpj)
    {
        cnpj = Regex.Replace(cnpj, @"\D", "");

        if (cnpj.Length != 14 || IsRepeatedDigits(cnpj))
            return false;

        int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCnpj = cnpj.Substring(0, 12);
        int soma = 0;

        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        int digito1 = resto < 2 ? 0 : 11 - resto;

        tempCnpj += digito1;
        soma = 0;

        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        return cnpj.EndsWith(digito1.ToString() + digito2.ToString());
    }

    private static bool IsRepeatedDigits(string value)
    {
        return new string(value[0], value.Length) == value;
    }
}
