using System.Text.RegularExpressions;

namespace XBank.Domain.Shared.Util
{
    public static class RegexsMatches
    {
        public static readonly Regex onlyLettersRegex = new Regex(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$");
        public static readonly Regex onlyNumbersRegex = new Regex(@"^\d+$");
        public static readonly Regex phoneRegex = new Regex(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$");
    }
}
