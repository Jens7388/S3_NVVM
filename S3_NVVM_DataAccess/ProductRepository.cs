using Microsoft.EntityFrameworkCore;
using S3_NVVM_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S3_MVVM_DataAccess
{
    public class ProductRepository: RepositoryBase<Product>
    {
        protected const string supplier = "Supplier";

        public override Product GetBy(int id)
        {
            return context.Products
                .Include(supplier)
                .SingleOrDefault(p => p.ProductId == id);
        }

        public override IEnumerable<Product> GetAll()
        {
            return context.Products.Include(supplier);
        }
    }
}
