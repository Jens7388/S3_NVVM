using Microsoft.EntityFrameworkCore;
using S3_NVVM_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S3_MVVM_DataAccess
{
    public class SupplierRepository: RepositoryBase<Supplier>
    {
        protected const string products = "Products";
        public override Supplier GetBy(int id)
        {
            return context.Suppliers
                .Include(products)
                .SingleOrDefault(p => p.SupplierId == id);
        }

        public override IEnumerable<Supplier> GetAll()
        {
            return context.Suppliers.Include(products);
        }
    }
}
