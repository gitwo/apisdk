using System;
using System.Security.Cryptography;
using System.Text;

namespace EShopApi.SDK.Util
{
	public class Encryptions
	{
		/// <summary>
		/// HMAC Sha256 加密
		/// </summary>
		/// <param name="inputString"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string HmacSha256(string inputString, string key)
		{
			using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
			{
				return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(inputString)));
			}
		}



	}
}
