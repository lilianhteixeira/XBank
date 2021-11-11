using System.ComponentModel;

namespace XBank.Domain.Core.Enums
{
    public enum MovementEnum
    {
        [Description("Retirada")]
        Withdraw = 1,

        [Description("Transferencia entre contas")]
        InternalTransfer = 2,

        [Description("Transferencia entre bancos")]
        ExternalTransfer = 3,

        [Description("Deposito")]
        Deposit = 4,
    }
}
