﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagment.BAL.DTO
{
 public	class UserVM
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
		public string Mobile { get; set; }
		public string Role { get; set; }
	}
}