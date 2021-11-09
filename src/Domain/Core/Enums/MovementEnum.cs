using System.ComponentModel;

namespace XBank.Domain.Core.Enums
{
    public enum MovementEnum
    {
        [Description("Retirada")]
        Withdraw = 1,

        [Description("Transferencia")]
        InternalTransfer = 2,

        [Description("Transferencia")]
        ExternalTransfer = 3,

        [Description("Deposito")]
        Deposit = 4,
    }
}
