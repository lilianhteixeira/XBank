using FluentValidation;
using XBank.Domain.Core.Requests;
using XBank.Domain.Shared.Validators;

namespace XBank.Domain.Core.Validators
{
    public class AddAClientRequestValidator : AbstractValidator<AddClientRequest>
    {
        public AddAClientRequestValidator()
        {
            Include(new ClientRequestValidator());

            RuleFor(x => x.CPF)
                .NotEmpty()
                .Must(ValidateCPF)
				.WithMessage("Enter the CPF numbers only.");

        }

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

			if (cpf ==  null || cpf.Length != 11)
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
