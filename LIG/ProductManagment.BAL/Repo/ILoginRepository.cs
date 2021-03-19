using ProductManagment.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagment.BAL.Repo
{
	public interface ILoginRepository
	{
		UserVM Login(LoginVM login);

	}
}
