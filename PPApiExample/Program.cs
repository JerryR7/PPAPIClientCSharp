using System;
using PPAPI_Client;

namespace PPApiExample
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var apiClient = new PPAPI_Client.PPApiClient("E389D1045757CA65902825C92D0F", "7sblc4cBDINfhMO4Lp_WtmqB0U4bhv0bGDg7EVbK", true);

			//PaymentPostReqATMVO vo = new PaymentPostReqATMVO(3);

			//apiClient.postPayment(vo);

			//apiClient.getRefund("refundid");
			//apiClient.getToken();
			apiClient.getTokenObject();

			Console.WriteLine("Hello World!");
		}
	}
}
