using GraphOfOrders.Lib.Entities;

namespace GraphOfOrders.Repo;

public class CustomerCompanyRepository : BaseRepository<CustomerCompany>
{
    public CustomerCompanyRepository(AccountingContext context) : base(context) {}
    
    public async Task<CustomerCompany> AddCustomerCompanyAsync(CustomerCompany customerCompany)
    {
        await AddAsync(customerCompany);
        return customerCompany;
    }

    public async Task<CustomerCompany> GetCustomerCompanyAsync(int customerCompanyId)
    {
        return await GetByIdAsync(customerCompanyId);
    }

    public async Task<CustomerCompany> UpdateCustomerCompanyAsync(int id, CustomerCompany entryEntity)
    {
        var existingEntity = await GetByIdAsync(id);
        if (existingEntity == null)
        {
            throw new KeyNotFoundException($"CustomerCompany with Id {id} not found.");
        }
        
        
        existingEntity.Name = entryEntity.Name;
        existingEntity.Cnpj = entryEntity.Cnpj;
        existingEntity.StateRegistration = entryEntity.StateRegistration;
        existingEntity.MunicipalRegistration = entryEntity.MunicipalRegistration;
        existingEntity.Documents = entryEntity.Documents;
        existingEntity.CompanyType = entryEntity.CompanyType;
        existingEntity.TaxRegime = entryEntity.TaxRegime;
        existingEntity.CompanySize = entryEntity.CompanySize;
        

        await _context.SaveChangesAsync();
        return entryEntity;
    }

    public async Task<CustomerCompany> DeleteCustomerCompanyAsync(int customerId)
    {
        var existingEntity = await GetByIdAsync(customerId);
        if (existingEntity == null)
        {
            throw new KeyNotFoundException($"CustomerCompany with Id {customerId} not found.");
        }

        await DeleteAsync(customerId);
        
        return existingEntity;
    }
}