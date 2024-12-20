using GraphOfOrders.Lib.Entities;
using GraphOfOrders.Lib.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphOfOrders.Repo;

public class AccountingContext : DbContext
{
    public DbSet<CustomerCompany> CustomerCompany { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<ProcessAction> ProcessAction { get; set; }
    public DbSet<ProcessActionType> ProcessActionType { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<CustomerCompanyEmployee> CustomerCompanyEmployee { get; set; }
    public DbSet<Attachment> Attachment { get; set; }
    
    public AccountingContext(DbContextOptions<AccountingContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<CustomerCompany>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            
            entity.Property(e => e.Name).IsRequired();
            
            entity.Property(e => e.Cnpj).IsRequired();
            
            entity.Property(e => e.StateRegistration).IsRequired();
            
            entity.Property(e => e.MunicipalRegistration).IsRequired();
            
            entity.HasMany(cc => cc.Documents)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade); 
            
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
            
            entity.HasMany(cc => cc.CustomerCompanyEmployees)
                .WithOne(cce => cce.CustomerCompany)
                .HasForeignKey(cce => cce.CustomerCompanyId);
        });

        modelBuilder.Entity<ProcessAction>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            
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
            
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            
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
            
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            
            entity.Property(e => e.Name).IsRequired();
            
            var rolesConverter = new ValueConverter<IEnumerable<Roles>, string>(
                roles => string.Join(",", roles.Select(r => r.ToString())),
                roles => roles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(r => Enum.Parse<Roles>(r))
                    .ToList());
            
            entity.Property(e => e.Role)
                .HasConversion(rolesConverter)
                .IsRequired();
            
            entity.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            entity.HasMany(e => e.ProcessActions)
                .WithOne(pa => pa.Employee)
                .HasForeignKey(pa => pa.EmployeeId);
            
            entity.HasMany(e => e.CustomerCompanyEmployees)
                .WithOne(cce => cce.Employee)
                .HasForeignKey(cce => cce.EmployeeId);
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

        });

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.Id)
                .IsRequired()
                .HasMaxLength(36);

            entity.Property(e => e.FileName)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.Data)
                .IsRequired();

            entity.Property(e => e.ContentType)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Type)
                .IsRequired()
                .HasConversion<int>();

            // Optionally, configure any index
            entity.HasIndex(e => e.FileName);
        });
    }
    
}