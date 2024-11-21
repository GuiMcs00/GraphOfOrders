using System.Collections.Generic;
using Newtonsoft.Json;
using GraphOfOrders.Lib.Entities.Tenant;
using GraphOfOrders.Lib.Enums;

namespace GraphOfOrders.Lib.Entities;

/// <summary>
/// Usuários do Sistema
/// </summary>
public record TenantUser : TenantItemBase
{
    /// <summary>
    /// Create a Tenant User.
    /// </summary>
    [System.Text.Json.Serialization.JsonConstructor]
    [JsonConstructor]
    public TenantUser(string tenantId) : base(tenantId)
    {
    }
    /// <summary>
    /// Nome de Usuário
    /// </summary>
    public string Username { get; set; }
    /// <summary>
    /// E-mail de Usuário
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Função de Usuário
    /// </summary>
    public IEnumerable<Roles> Role { get; set; }
    
    
}