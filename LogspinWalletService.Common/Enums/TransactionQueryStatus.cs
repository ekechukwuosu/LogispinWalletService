using System.Text.Json.Serialization;

namespace LogispinWalletService.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionQueryStatus
    {
        Success,
        Pending,
        Failed,
        All
    }
}
