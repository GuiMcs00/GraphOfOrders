using System.Text.Json.Serialization;

namespace GraphOfOrders.Lib.Entities.Tenant;

public abstract record TenantItemBase(string TenantId) : ItemBase, ITenantBound
{
    /// <summary>
    /// Tenant ID of the message that created this item.
    /// This is also used as the Partition Key.
    /// </summary>
    [JsonPropertyName("tenantId")]
    public string TenantId { get; set; } = TenantId;
    
}