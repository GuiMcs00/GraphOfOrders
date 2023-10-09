using GraphOfOrders.Lib.Entities;
using System.Collections.Generic;

namespace GraphOfOrders.Lib.DI
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
    }

}
