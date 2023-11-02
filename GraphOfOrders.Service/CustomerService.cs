using System.Collections;
using AutoMapper;
using GraphOfOrders.Lib.DI;
using GraphOfOrders.Lib.DTOs;
using GraphOfOrders.Lib.Entities;
using GraphOfOrders.Lib.Exceptions;

namespace GraphOfOrders.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> CreateCustomer(CustomerInputDTO customer)
        {
            var createdCustomer = await _customerRepository.CreateCustomer(_mapper.Map<Customer>(customer));
            return _mapper.Map<CustomerDTO>(createdCustomer);
        }

        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            var customerEntity = await _customerRepository.GetCustomerById(id);
            if (customerEntity == null)
            {
                throw new NotFoundException($"Customer with ID {id} not found");
            }
            return _mapper.Map<CustomerDTO>(customerEntity);
        }

        public async Task<CustomerDTO> UpdateCustomer(int id, CustomerInputDTO updatedCustomerDTO)
        {
            var updatedCustomer = _mapper.Map<Customer>(updatedCustomerDTO);
            var result = await _customerRepository.UpdateCustomer(id, updatedCustomer);
            if (result == null)
            {
                throw new NotFoundException($"Customer with ID {id} not found");
            }
            return _mapper.Map<CustomerDTO>(result);
        }
        public IEnumerable<CustomerDTO> GetCustomers(int itemsPerPage, int page){
             var customers = _customerRepository.GetAllCustomers(itemsPerPage, page);
            var customersDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return customersDTOs;
        }
    }
}
