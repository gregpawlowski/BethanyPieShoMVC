using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Fruit pies", CategoryDescription="All-fruit pies"},
                new Category{CategoryId=2, CategoryName="Cheese cakes", CategoryDescription="Cheesy all the way!"},
                new Category{CategoryId=3, CategoryName="Seasonal pies", CategoryDescription="Get in the mood for a seasonal pie!"},
            };
    }
}
