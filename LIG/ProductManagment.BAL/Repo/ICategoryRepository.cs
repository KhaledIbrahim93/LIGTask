using ProductManagment.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagment.BAL.Repo
{
	public interface ICategoryRepository
	{
        IEnumerable<CategoryVM> GetAll();
        CategoryVM GetById(object id);
        void Insert(CategoryVM obj);
        void Update(CategoryVM obj);
        void Delete(int id);
        void Save();
    }
}
