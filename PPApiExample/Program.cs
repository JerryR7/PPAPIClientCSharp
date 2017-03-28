using System;
using PPApiClient;
using PPApiClient.ValueObject.Request;

namespace PPApiExample
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var apiClient = new PPApiClient.PPApiClient("E389D1045757CA65902825C92D0F", "7sblc4cBDINfhMO4Lp_WtmqB0U4bhv0bGDg7EVbK", true);

			PaymentPostReqVO vo = new PaymentPostReqVO();
			vo.amount = 100;

			apiClient.postPayment(vo);

			//apiClient.getRefund("refundid");
			//apiClient.getToken();
			// apiClient.getTokenObject();

			Console.WriteLine("Hello World!");
		}
	}
}
