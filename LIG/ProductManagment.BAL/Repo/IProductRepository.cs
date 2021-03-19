using ProductManagment.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagment.BAL.Repo
{
    public interface IProductRepository
    {
        IEnumerable<ProductVM> GetAll();
        ProductVM GetById(object id);
        void Insert(ProductVM obj);
        void Update(ProductVM obj);
        void Delete(int id);
        void Save();
    }
}
