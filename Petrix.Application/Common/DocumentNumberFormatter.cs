using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petrix.Application.Common
{
    public class DocumentNumberFormatter
    {
        public static string FormatCpf(string cpf)
        {
            var digits = new string(cpf.Where(char.IsDigit).ToArray());

            return digits.Length == 11
                ? $"{digits[..3]}.{digits[3..6]}.{digits[6..9]}-{digits[9..11]}"
                : cpf;
        }

        public static string FormatCnpj(string? cpnj)
        {

            if (string.IsNullOrWhiteSpace(cpnj))
                return "";

            var digits = new string(cpnj.Where(char.IsDigit).ToArray());

            return digits.Length == 14
                ? $"{digits[..2]}.{digits[2..5]}.{digits[5..8]}/{digits[8..11]}-{digits[11..13]}"
                : cpnj;
        }
    }
}