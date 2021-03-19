using ProductManagment.BAL.Repo;
using ProductManagment.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagment.BAL.DTO;
namespace ProductManagment.BAL.Services
{
    public class ProductRepository: IProductRepository 
	{
        private LIGDbEntities _context = null;
        public ProductRepository()
        {
            this._context = new LIGDbEntities();
        }
        public ProductRepository(LIGDbEntities _context)
        {
            this._context = _context;
        }
       
        public void Save()
        {
            _context.SaveChanges();
        }

		public IEnumerable<ProductVM> GetAll()
		{
			var entity = _context.Products.Where(e=>e.IsActive==true && e.IsDeleted==false).ToList();
			return entity.Select(e => new ProductVM()
			{
				Price = e.Price,
				ProducrName = e.ProducrName,
				CategoryId = e.CategoryId,
				CreatedOn = e.CreatedOn,
				UpdatedOn = e.UpdatedOn
			});
		}

		public ProductVM GetById(object id)
		{
			throw new NotImplementedException();
		}

		public void Insert(ProductVM obj)
		{
			var product = new Product()
			{
				Price = obj.Price,
				CategoryId = obj.CategoryId,
				ProducrName = obj.ProducrName,
				CreatedOn = DateTime.Now,
				IsDeleted = false,
				IsActive = true
			};
			_context.Products.Add(product);
		}

		public void Update(ProductVM obj)
		{
			throw new NotImplementedException();
		}

		

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
