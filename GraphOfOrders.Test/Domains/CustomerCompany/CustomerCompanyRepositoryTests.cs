using GraphOfOrders.Repo;
using Microsoft.EntityFrameworkCore;
using GraphOfOrders.Lib.Entities;
using System.Threading.Tasks;
using GraphOfOrders.Lib.Enums;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace GraphOfOrders.Test.Domains.CustomerCompany
{
    public class TestDataFactory
    {
        public static Lib.Entities.CustomerCompany CustomerPayload()
        {
            return new Lib.Entities.CustomerCompany("Contelb")
            {
                Id = "1",
                Name = "Test",
                Cnpj = "000",
                StateRegistration = "000",
                MunicipalRegistration = "000",
                TaxRegime = TaxRegime.SimplesNacional,
                CompanyType = CompanyType.MEI,
                CompanySize = CompanySize.Microempresa
            };
        }
    }
    
    public class CustomerCompanyRepositoryTests : IDisposable
    {
        private readonly AccountingContext _context;
        private readonly CustomerCompanyRepository _repo;

        public CustomerCompanyRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AccountingContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AccountingContext(options);
            _repo = new CustomerCompanyRepository(_context);
        }
        
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
        
        [Fact]
        public async Task Should_Create_New_CustomerCompany()
        {
            // Arrange
            var customer = TestDataFactory.CustomerPayload();
                
            // Act
            var result = await _repo.AddCustomerCompanyAsync(customer);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test", result.Name);
            Assert.Equal("000", result.Cnpj);
        }

        [Fact]
        public async Task Should_Return_CustomerCompany()
        {
            var companyId = "1";
            
            await _repo.AddCustomerCompanyAsync(TestDataFactory.CustomerPayload());
            
            var result = await _repo.GetCustomerCompanyAsync(companyId);
            
            Assert.NotNull(result);
            Assert.Equal(companyId, result.Id);
        }

        [Fact]
        public async Task Should_Update_CustomerCompany()
        {
            var companyNewTaxRegime = TaxRegime.LucroPresumido;
            var companyNewCompanySize = CompanySize.EmpresaDePequenoPorte;
            
            var customerCompany = TestDataFactory.CustomerPayload();
            await _repo.AddCustomerCompanyAsync(customerCompany);
            var customerTaxRegime = customerCompany.TaxRegime;
            var customerCompanySize = customerCompany.CompanySize;
            var customerBefore = await _repo.GetCustomerCompanyAsync(customerCompany.Id);
            
            customerBefore.TaxRegime = companyNewTaxRegime;
            customerBefore.CompanySize = companyNewCompanySize;

            var result = await _repo.UpdateCustomerCompanyAsync(customerCompany.Id, customerBefore);
            
            Assert.NotNull(result);
            Assert.Equal(customerBefore.TaxRegime, result.TaxRegime);
            Assert.Equal(customerBefore.CompanySize, result.CompanySize);
            Assert.NotEqual(customerTaxRegime, result.TaxRegime);
            Assert.NotEqual(customerCompanySize, result.CompanySize);
            
        }

        [Fact]
        public async Task Should_Delete_CustomerCompany()
        {
            var customerCompany = TestDataFactory.CustomerPayload();
            
            await _repo.AddCustomerCompanyAsync(customerCompany);
            
            var deletedEntity = await _repo.DeleteCustomerCompanyAsync(customerCompany.Id);
            
            Assert.NotNull(deletedEntity);
            Assert.Equal(customerCompany.Id, deletedEntity.Id);
            
            var result = await _repo.GetCustomerCompanyAsync(customerCompany.Id);
            Assert.Null(result);
        }

        
    }
}