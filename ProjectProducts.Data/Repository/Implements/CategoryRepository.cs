using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProducts.Data.Repository.Implements
{
    public class CategoryRepository : GenericRepository<Categories> ,ICategoryRepository
    {
        public CategoryRepository(ProductDBContext productDBContext) : base(productDBContext)
        {
        }

    }
}
