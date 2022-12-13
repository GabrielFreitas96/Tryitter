using System;
using System.Security.Cryptography;
using System.Text;
namespace Tryitter.Helpers
{
	public static class GenerateHash
	{

		public static string Generate(string password)
		{
			var md5 = MD5.Create();
			byte[] bytes = Encoding.ASCII.GetBytes(password);
			byte[] hash = md5.ComputeHash(bytes);
			return Convert.ToBase64String(hash);
		}
	}
}

