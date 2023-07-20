using BlogProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity.Entities
{
	public class NewsLatter : EntityBase
	{
		public NewsLatter()
		{

		}
		public NewsLatter(string mail)
		{
			Mail=mail;
		}
		public string Mail { get; set; }
	}
}
