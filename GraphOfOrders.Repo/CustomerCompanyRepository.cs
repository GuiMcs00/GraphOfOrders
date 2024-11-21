using GraphOfOrders.Lib.Entities;

namespace GraphOfOrders.Repo;

public class CustomerCompanyRepository : BaseRepository<CustomerCompany>
{
    public CustomerCompanyRepository(AccountingContext context) : base(context) {}
    
    public async Task<CustomerCompany> AddCustomerCompanyAsync(CustomerCompany customerCompany)
    {
        var addedEntity = await AddAsync(customerCompany);
        return addedEntity;
    }

    public async Task<CustomerCompany> GetCustomerCompanyAsync(string customerCompanyId)
    {
        return await GetByIdAsync(customerCompanyId);
    }

    public async Task<CustomerCompany> UpdateCustomerCompanyAsync(string id, CustomerCompany entryEntity)
    {
        var updatedEntity = await UpdateAsync(id, entryEntity);

        return updatedEntity;
    }

    public async Task<CustomerCompany> DeleteCustomerCompanyAsync(string customerId)
    {
        var deletedEntity = await DeleteAsync(customerId);
        
        return deletedEntity;
    }
}