namespace GraphOfOrders.Lib.Entities.Tenant;

/// <summary>
/// Tenant Bound Item.
/// </summary>
public interface ITenantBound 
{
    /// <summary>
    /// Tenant ID of the Item.
    /// </summary>
    public string TenantId { get; set; }
}