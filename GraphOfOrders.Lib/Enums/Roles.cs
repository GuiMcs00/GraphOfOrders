using System.Collections.Generic;

namespace GraphOfOrders.Lib.Enums
{
    /// <summary>
    /// Função de usuários
    /// </summary>
    public enum Roles
    {
        Admin,
        Legal,
        AccountingEmployee,
        AccountingSupervisor,
        PeopleEmployee,
        PeopleSupervisor,
        TaxEmployee,
        TaxSupervisor,
        Customer
    }

    // /// <summary>
    // /// Modelo de uma função de usuário com permissões
    // /// </summary>
    // public class Role
    // {
    //     public Roles Name { get; set; }
    //     public List<Roles> Inherits { get; set; } = new List<Roles>();
    //     public List<string> Permissions { get; set; } = new List<string>();
    //
    //     public Role(Roles name, List<string> permissions, List<Roles> inherits = null)
    //     {
    //         Name = name;
    //         Permissions = permissions;
    //         Inherits = inherits ?? new List<Roles>();
    //     }
    // }
    //
    // /// <summary>
    // /// Definições das funções e permissões
    // /// </summary>
    // public static class RoleDefinitions
    // {
    //     public static List<Role> Roles = new List<Role>
    //     {
    //         new Role(Roles.Admin, new List<string>
    //         {
    //             "read:all:customers",
    //             "write:all:customers",
    //             "update:all:customers"
    //         }),
    //         new Role(Roles.Legal, new List<string>
    //         {
    //             "read:all:customers",
    //             "write:all:docs",
    //             "update:all:docs"
    //         }),
    //         new Role(Roles.AccountingEmployee, new List<string>
    //         {
    //             "read:own:customers",
    //             "write:own:customers",
    //             "update:own:customers"
    //         }),
    //         new Role(Roles.AccountingSupervisor, new List<string>
    //         {
    //             "read:department:customers",
    //             "write:department:customers",
    //             "update:department:customers"
    //         }, new List<Roles> { Roles.AccountingEmployee }),
    //         new Role(Roles.PeopleEmployee, new List<string>
    //         {
    //             "read:own:people",
    //             "write:own:people",
    //             "update:own:people"
    //         }),
    //         new Role(Roles.PeopleSupervisor, new List<string>
    //         {
    //             "read:department:people",
    //             "write:department:people",
    //             "update:department:people"
    //         }, new List<Roles> { Roles.PeopleEmployee }),
    //         new Role(Roles.TaxEmployee, new List<string>
    //         {
    //             "read:own:receipts",
    //             "write:own:taxes",
    //             "update:own:taxes",
    //             "upload:own:financial_documents"
    //         }),
    //         new Role(Roles.TaxSupervisor, new List<string>
    //         {
    //             "read:department:receipts",
    //             "write:department:taxes",
    //             "update:department:taxes",
    //             "upload:department:financial_documents"
    //         }, new List<Roles> { Roles.TaxEmployee }),
    //         new Role(Roles.Customer, new List<string>
    //         {
    //             "read:own:data",
    //             "write:own:data",
    //             "update:own:data",
    //             "read:own:employees",
    //             "write:own:employees",
    //             "update:own:employees",
    //             "read:own:partners",
    //             "write:own:partners",
    //             "update:own:partners"
    //         })
    //     };
    // }
}
