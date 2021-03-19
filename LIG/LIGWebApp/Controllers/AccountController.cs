using ProductManagment.BAL.DTO;
using ProductManagment.BAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIGWebApp.Controllers
{
	public class AccountController : Controller
	{
		readonly ILoginRepository _repo;
		public AccountController(ILoginRepository repo)
		{
			_repo = repo;
		}
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Login(LoginVM login)
		{

			var user = _repo.Login(login);
			if (user != null)
			{
				if (user.Role== "Admin")
				{
					Session["Admin"] = user.Role;
				}
				else if(user.Role == "Manager")
				{
					Session["Manager"] = user.Role;
				}
				else
				{
					Session["Customer"] = user.Role;
				}
				return RedirectToAction("Index", "Product");
			}
			else
			{
				return View();
			}

		}
		public ActionResult LogOut()
		{
			Session.Remove("Admin");
			Session.Remove("Manager");
			Session.Remove("Customer");
			return RedirectToAction("Index", "Account");
		}
	}
}