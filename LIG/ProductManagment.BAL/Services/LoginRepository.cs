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
	public class LoginRepository : ILoginRepository
	{
		private LIGDbEntities _context = null;
		public LoginRepository()
		{
			this._context = new LIGDbEntities();
		}
		public LoginRepository(LIGDbEntities _context)
		{
			this._context = _context;
		}
		public UserVM Login(LoginVM login)
		{
			var user = _context.Users.Where(e => e.UserName == login.UserName && e.Password == login.Password).FirstOrDefault();
			if (user!=null)
			{
				var roleId = _context.UserRoles.Where(e => e.UserId == user.Id).Select(e => e.RoleId).FirstOrDefault();
				var roleName = _context.Roles.Where(e => e.Id == roleId).Select(e => e.Name).FirstOrDefault();
				return new UserVM()
				{
					Address = user.Address,
					UserName = user.UserName,
					Mobile = user.Mobile,
					Role=roleName
				};
			}
			return new UserVM();
		}
	}
}
