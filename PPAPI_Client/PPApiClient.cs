using System;
using RestSharp;
using RestSharp.Authenticators;

namespace PPAPI_Client
{
	public class PPApiClient
	{
		const int TOKEN_EXPIRE_SEC = 1800; //30 * 60;  //30 minutes
		const string BASE_URL = "https://api.pchomepay.com.tw/v1";
		const string SB_BASE_URL = "https://sandbox-api.pchomepay.com.tw/v1";

		string tokenURL;
		string postPaymentURL;
		string getPaymentURL;
		string postPaymentAtmVAURL;
		string postPaymentAuditURL;
		string getPaymentAtmBanksURL;
		string getPaymentCardBanksURL;
		string getRefundURL;
		string postRefundURL;
		string postWithdrawURL;
		string getCheckingURL;
		string getBalanceURL;
		string userAuth;

		string secret;

		string userId;

		string baseURL;

		TokenPostRspVO token;



		public PPApiClient(string userId, 
		                   string secret, 
		                   //ITokenStorage tokenStorage = null, 
		                   bool sandBox = false)
		{
			baseURL = sandBox?  SB_BASE_URL : BASE_URL;

	        this.tokenURL = "/token";
			this.postPaymentURL = "/payment";
			this.getPaymentURL = "/payment/{order_id}";
			this.postPaymentAtmVAURL = "/payment/atmva";
			this.postPaymentAuditURL = "/payment/audit";
			this.getPaymentAtmBanksURL = "/payment/atm/banks";
			this.getPaymentCardBanksURL = "/payment/card/banks";
			this.getRefundURL = "/refund/{refund_id}";
			this.postRefundURL = "/refund";
			this.postWithdrawURL = "/withdraw";
			this.getCheckingURL = "/checking/{date}/{type}";
			this.getBalanceURL = "/balance";

			this.userId = userId;
			this.secret = secret;
			//if ($tokenStorage == null) {
	  //          $tokenStorage = new SessionTokenStorage();
			//}

	  //      $this->tokenStorage = $tokenStorage;

	  //      $this->ignoreSSL = $ignoreSSL;
		}


		public void getToken()
		{
			var client = new RestClient(this.baseURL);

			client.Authenticator = new HttpBasicAuthenticator(this.userId, this.secret);

			var request = new RestRequest(this.tokenURL, Method.POST);
			var response = client.Execute<TokenPostRspVO>(request);
			if (response.ErrorException != null)
			{
				Console.Out.Write(response.ErrorException);
				var message = response.Content;
				var ppException = new ApplicationException(message, response.ErrorException);
				throw ppException;
			}

			this.token = response.Data; // raw content as string

			Console.Out.Write(token.ToString());
		}

		public RefundGetRspVO postPayment(IPaymentReqVO vo)
		{
			var request = new RestRequest(this.getRefundURL, Method.POST);
			request.AddObject(vo);
			return this.Execute<RefundGetRspVO>(request);
		}

		public RefundGetRspVO getRefund(string refudId)
		{
			var request = new RestRequest(this.getRefundURL, Method.POST);
			request.AddParameter("refund_id", refudId);
			return this.Execute<RefundGetRspVO>(request);
		}

		public TokenPostRspVO getTokenObject()
		{
			/// <summary>
			/// 
			/// </summary>
			/// <TODO>
			/// add code to cache token
			/// </TODO>
			/// <param name="request">Request.</param>
			/// <typeparam name="T">The 1st type parameter.</typeparam>

			if (this.token == null)
			{
				this.getToken();
			}

			return this.token;
		}

		private T Execute<T>(RestRequest request) where T : new()
		{
			var client = new RestClient();
			client.BaseUrl = new System.Uri(baseURL);

			var tokenObj = this.getTokenObject();

			request.AddHeader("pcpay-token",  tokenObj.token);

			var response = client.Execute<T>(request);

			if (response.ErrorException != null)
			{
				string message = response.Content;
				var ppException = new ApplicationException(message, response.ErrorException);
				throw ppException;
			}
			return response.Data;
		}


	}
}
