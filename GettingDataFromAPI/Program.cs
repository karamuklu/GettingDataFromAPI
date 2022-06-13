using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;


namespace GettingDataFromAPI
{
	class Program
	{
		static void Main(string[] args)
		{
			Methods methods = new Methods();
			var token= methods.GetToken("service", "serv1234", "https://webservice.tsoft.com.tr/rest1/auth/login/service");
			var list = methods.GetCategories(token, "https://webservice.tsoft.com.tr/rest1/category/getCategories");
			foreach (var item in list)
			{
				Console.WriteLine(item.CategoryName);
			}
		}


	}

	
}
