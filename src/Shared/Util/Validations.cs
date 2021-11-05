using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBank.Domain.Shared.Util
{
    public static class Validations
    {
        public static bool ValidateCPF(string cpf)
        {
			// Creditos ao Macoratti
			// http://www.macoratti.net/11/09/c_val1.htm

			int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digit;
			int sum;
			int resto;
			
			if (cpf.Length != 11)
				return false;

			tempCpf = cpf.Substring(0, 9);
			sum = 0;

			for (int i = 0; i < 9; i++)
				sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

			resto = sum % 11;

			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			digit = resto.ToString();
			tempCpf += digit;
			sum = 0;

			for (int i = 0; i < 10; i++)
				sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

			resto = sum % 11;

			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			digit += resto.ToString();

			return cpf.EndsWith(digit);
		}

	}
}
