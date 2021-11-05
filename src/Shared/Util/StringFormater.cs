using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
