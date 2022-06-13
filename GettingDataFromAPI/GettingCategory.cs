using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDataFromAPI
{
	public class GettingCategory
	{
		public IList<Category> data { get; set; }
		public bool success { get; set; }
		public IList<message> message { get; set; }
		public summary summary { get; set; }
	}
}
