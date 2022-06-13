using GettingDataFromAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace GettingDataFromAPI
{
	public class Methods
	{
		public string GetToken(string username, string password, string url)
		{
			UriBuilder builder = new UriBuilder(url);
			builder.Query = "user=" + username + "&pass=" + password + "";
			HttpClient client = new HttpClient();
			var result = client.GetAsync(builder.Uri).Result;
			StreamReader sr = new StreamReader(result.Content.ReadAsStreamAsync().Result);
			var answer = sr.ReadToEnd().Normalize().ToString();
			GettingToken accessTokenModel = JsonConvert.DeserializeObject<GettingToken>(answer);
			var token = accessTokenModel.data.FirstOrDefault().token;
			return token;
		}
		public List<Category> GetCategories(string token, string url)
		{
			List<Category> list = new List<Category>();
			HttpClient client = new HttpClient();
			var serviceUrl = url;
			List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>( "grant_type", "password" ),
				new KeyValuePair<string, string>( "token", token),
			};
			HttpContent content = new FormUrlEncodedContent(pairs);
			HttpResponseMessage response = client.PostAsync(serviceUrl, content).Result;
			StreamReader sr = new StreamReader(response.Content.ReadAsStreamAsync().Result);
			var answer = sr.ReadToEnd().Normalize().ToString();
			var accessTokenModel = JsonConvert.DeserializeObject<GettingCategory>(answer);
			list.AddRange(accessTokenModel.data);
			return list;
		}
	}
}
