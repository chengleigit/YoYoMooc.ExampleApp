using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace YoYoMooc.ExampleApp.Models
{
    public class MockProductRepository : IProductRepository
    {

       private static readonly Product[] DummyData = new Product[] {
new Product { Name = "产品1", Category = "分类1", Price = 1001 },
new Product { Name = "产品2", Category = "分类1", Price = 1002 },
new Product { Name = "产品3", Category = "分类2", Price = 1003 },
new Product { Name = "产品4", Category = "分类2", Price = 1004 },
};
        public IQueryable<Product> Products => DummyData.AsQueryable();

     }
}