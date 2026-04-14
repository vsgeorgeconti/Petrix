namespace Petrix.Domain.Utils
{
    public static class CpfValidator
    {
        public static bool IsValid(string cpf)
        {
            var digits = new string(cpf.Where(char.IsDigit).ToArray());

            if (digits.Length != 11) return false;

            if (digits.Distinct().Count() == 1) return false;

            // Valida 1º dígito verificador
            if (!ValidateDigit(digits, 10)) return false;

            // Valida 2º dígito verificador
            if (!ValidateDigit(digits, 11)) return false;

            return true;
        }

        private static bool ValidateDigit(string digits, int weight)
        {
            var sum = digits
                .Take(weight - 1)
                .Select((d, i) => int.Parse(d.ToString()) * (weight - i))
                .Sum();

            var remainder = (sum * 10) % 11;
            var expected = remainder == 10 ? 0 : remainder;

            return int.Parse(digits[weight - 1].ToString()) == expected;
        }
    }

}