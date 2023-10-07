using GraphOfOrders.Lib.DTOs;
using System.Collections.Generic;

namespace GraphOfOrders.Lib.DI
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetAllCategories();
    }
}