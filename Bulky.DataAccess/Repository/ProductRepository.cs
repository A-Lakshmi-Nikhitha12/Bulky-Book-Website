using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Product obj)
        {
            // _db.Products.Update(obj);
            var objfromDB = _db.Products.FirstOrDefault(p => p.Id == obj.Id);
            if (objfromDB != null)
            {
                objfromDB.Title = obj.Title;
                objfromDB.ISBN = obj.ISBN;
                objfromDB.Price = obj.Price;
                objfromDB.Price50 = obj.Price50;
                objfromDB.ListPrice = obj.ListPrice;
                objfromDB.Price100 = obj.Price100;
                objfromDB.Description = obj.Description;
                objfromDB.CategoryId = obj.CategoryId;
                objfromDB.Author = obj.Author;
                if (objfromDB.ImageUrl != null)
                {
                    objfromDB.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
