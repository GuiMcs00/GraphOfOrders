using GraphOfOrders.Lib.Entities;
using GraphOfOrders.Lib.Enums;
using Microsoft.EntityFrameworkCore;

namespace GraphOfOrders.Repo;

public class AccountingContext : DbContext
{
    public DbSet<CustomerCompany> CustomerCompanies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<ProcessAction> ProcessActions { get; set; }
    public DbSet<ProcessActionType> ProcessActionTypes { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<CustomerCompanyEmployee> CustomerCompanyEmployees { get; set; }
    
    public AccountingContext(DbContextOptions<AccountingContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<CustomerCompany>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Cnpj).IsRequired();
            entity.Property(e => e.StateRegistration).IsRequired();
            entity.Property(e => e.MunicipalRegistration).IsRequired();
            entity.Property(e => e.Documents);
            
            entity.Property(e => e.TaxRegime)
                .HasConversion<int>()
                .IsRequired();
            
            entity.Property(e => e.CompanyType)
                .HasConversion<int>()
                .IsRequired();
            
            entity.Property(e => e.CompanySize)
                .HasConversion<int>()
                .IsRequired();

            entity.HasMany(cc => cc.ProcessActions)
                .WithOne(pa => pa.CustomerCompany)
                .HasForeignKey(pa => pa.CustomerCompanyId);
        });

        modelBuilder.Entity<ProcessAction>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CompetencyDate).IsRequired();
            
            entity.Property(e => e.Recurrence)
                .HasConversion<int>()
                .IsRequired();
            
            entity.HasOne(e => e.ProcessActionType)
                .WithMany(p => p.ProcessActions)
                .HasForeignKey(e => e.ProcessActionTypeId);
            
            entity.HasOne(e => e.Employee)
                .WithMany(em => em.ProcessActions)
                .HasForeignKey(e => e.EmployeeId);

            entity.HasOne(e => e.CustomerCompany)
                .WithMany(c => c.ProcessActions)
                .HasForeignKey(e => e.CustomerCompanyId);
        });

        modelBuilder.Entity<ProcessActionType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            
            entity.HasOne(e => e.Department)
                .WithMany(d => d.ProcessActionTypes)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.Property(e => e.ActionTypeName)
                .IsRequired()
                .HasMaxLength(100);
        });
        
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            
            entity.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            entity.HasMany(e => e.ProcessActions)
                .WithOne(pa => pa.Employee)
                .HasForeignKey(pa => pa.EmployeeId);
        });
        
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            
            entity.HasOne(e => e.Supervisor)
                .WithMany()
                .HasForeignKey(e => e.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            entity.HasMany(d => d.ProcessActionTypes)
                .WithOne(pa => pa.Department)
                .HasForeignKey(pa => pa.DepartmentId);
        });
        
        modelBuilder.Entity<CustomerCompanyEmployee>(entity =>
        {
            entity.HasKey(ce => new { ce.EmployeeId, ce.CustomerCompanyId });

            entity.HasOne(ce => ce.Employee)
                .WithMany(e => e.CustomerCompanyEmployees)
                .HasForeignKey(ce => ce.EmployeeId);

            entity.HasOne(ce => ce.CustomerCompany)
                .WithMany(c => c.CustomerCompanyEmployees)
                .HasForeignKey(ce => ce.CustomerCompanyId);

            /// entity.Property(ce => ce.Role).HasMaxLength(100);
        });
    }
    
    private static object ConvertToSpecificActionType(string actionTypeName, int departmentId)
    {
        return departmentId switch
        {
            1 => Enum.Parse(typeof(AccountingProcessTypes), actionTypeName),
            2 => Enum.Parse(typeof(PeopleProcessTypes), actionTypeName),
            3 => Enum.Parse(typeof(LegalProcessTypes), actionTypeName),
            4 => Enum.Parse(typeof(TaxProcessTypes), actionTypeName),

            _ => throw new ArgumentException("Tipo de departamento inválido.")
        };
    }
}