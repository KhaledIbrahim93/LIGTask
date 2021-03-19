using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagment.BAL.DTO
{
	public class ProductVM
	{
		public int Id { get; set; }
		public string ProducrName { get; set; }
        public string Price { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public  int? CategoryId { get; set; }
		public string CategoryName { get; set; }
		public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
