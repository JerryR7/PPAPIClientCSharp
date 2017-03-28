using System;
namespace PPAPI_Client
{
	public class TokenPostRspVO : ResponseBaseVO
	{
		public string token;
		public int expired_in;
		public int expired_timestamp;

		public TokenPostRspVO()
		{
			
		}
	}
}
