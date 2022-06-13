using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDataFromAPI
{
	public class GettingToken
	{
		public IList<data> data { get; set; }
		public bool success { get; set; }
		public IList<message> message { get; set; }
		public string summary { get; set; }
		//public string user_name { get; set; }
	}
}
