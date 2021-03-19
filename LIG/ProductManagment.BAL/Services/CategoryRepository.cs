using ProductManagment.BAL.DTO;
using ProductManagment.BAL.Repo;
using ProductManagment.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagment.BAL.Services
{
	public class CategoryRepository : ICategoryRepository
	{
		private LIGDbEntities _context = null;
		public CategoryRepository()
		{
			this._context = new LIGDbEntities();
		}
		public CategoryRepository(LIGDbEntities _context)
		{
			this._context = _context;
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CategoryVM> GetAll()
		{
			var entity = _context.Categories.Where(e => e.IsActive == true && e.IsDeleted == false).ToList();
			return entity.Select(e => new CategoryVM()
			{
				CreatedOn=e.CreatedOn,
				Name=e.Name,
				MetadataId=e.MetadataId,
				 UpdatedOn=e.UpdatedOn
			});
		}

		public CategoryVM GetById(object id)
		{
			throw new NotImplementedException();
		}

		public void Insert(CategoryVM obj)
		{
			var category = new Category()
			{
				Name = obj.Name,
				CreatedOn = DateTime.Now,
				IsDeleted = false,
				IsActive = true,
				MetadataId=obj.MetadataId
			};
			_context.Categories.Add(category);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(CategoryVM obj)
		{
			throw new NotImplementedException();
		}
	}
}
