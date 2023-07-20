using Casgem.DataAccessLayer.Abstract;
using Casgem.DataAccessLayer.Conrete;
using Casgem.DataAccessLayer.Repositories;
using Casgem.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casgem.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(Context context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            using var context = new Context();
            return context.Products.Include(x=>x.Category).ToList();
        }
    }
}
