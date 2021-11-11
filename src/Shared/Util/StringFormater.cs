namespace XBank.Domain.Shared.Util
{
    public static class StringFormater
    {
        public static string FormatCPF(string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace("-", "");
        }
    }
}
