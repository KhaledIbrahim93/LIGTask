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
			var entity = _context.Products.Where(e=>e.IsActive==true && e.IsDeleted==false).Include(e=>e.Category).ToList();
			return entity.Select(e => new ProductVM()
			{
				Id=e.Id,
				Price = e.Price,
				ProducrName = e.ProducrName,
				CategoryId = e.CategoryId,
				CategoryName=e.Category.Name,
				CreatedOn = e.CreatedOn,
				UpdatedOn = e.UpdatedOn
			});
		}

		public ProductVM GetById(int id)
		{
		 var entity=_context.Products.Where(e => e.Id ==id).FirstOrDefault();
			return new ProductVM()
			{
				ProducrName = entity.ProducrName,
				IsActive = entity.IsActive,
				CreatedOn = entity.CreatedOn,
				Price = entity.Price,
				Id = entity.Id,
				CategoryId=entity.CategoryId

			};
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
			var entity = _context.Products.Where(e => e.Id == obj.Id).FirstOrDefault();
			if (entity!=null)
			{
				entity.Price = obj.Price;
				entity.ProducrName = obj.ProducrName;
				entity.IsActive = true;
				entity.UpdatedOn = DateTime.Now;
			}
		}
		public void Delete(ProductVM obj)
		{
			var entity = _context.Products.Where(e => e.Id == obj.Id).FirstOrDefault();
			entity.IsDeleted = true;
		}
		public void ArchiveProduct(List<int> ids)
		{
			var products = _context.Products.Where(e => ids.Contains(e.Id)).ToList();
			foreach (var item in products)
			{
				var entity = products.Where(e => e.Id == item.Id).FirstOrDefault();
				entity.IsDeleted = true;
				Save();
			}
		}
		public IEnumerable<ProductVM> SearchWithDate(DateTime date)
		{
			var entity = _context.Products.Where(e => e.IsActive == true 
			&& e.IsDeleted == false && e.CreatedOn.Value.Date==date.Date).Include(e => e.Category).ToList();
			return entity.Select(e => new ProductVM()
			{
				Id = e.Id,
				Price = e.Price,
				ProducrName = e.ProducrName,
				CategoryId = e.CategoryId,
				CategoryName = e.Category.Name,
				CreatedOn = e.CreatedOn,
				UpdatedOn = e.UpdatedOn
			});
		}
	}
}
