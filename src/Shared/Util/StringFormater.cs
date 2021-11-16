namespace XBank.Domain.Shared.Util
{
    public static class StringFormater
    {
        public static string FormatCPF(string cpf)
        {
            if (cpf == null) return cpf;

            return cpf.Trim().Replace(".", "").Replace("-", "");
        }
    }
}
