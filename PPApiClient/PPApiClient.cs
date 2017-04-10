using System;
using PPApiClient.Entity;
using PPApiClient.Storage;
using PPApiClient.ValueObject.Request;
using PPApiClient.ValueObjects.Response;
using RestSharp;
using RestSharp.Authenticators;

namespace PPApiClient {
	public class PPApiClient {
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
		// string userAuth;

		string secret;

		string userId;

		string baseURL;

		TokenEntity tokenObj;
        private ITokenStorage tokenStorage;

		public PPApiClient(string userId,
			string secret,
			bool sandBox) : this(userId, secret, null, sandBox){
				
			}

        public PPApiClient(string userId,
			string secret,
			ITokenStorage tokenStorage = null, 
			bool sandBox = false) {
			baseURL = sandBox ? SB_BASE_URL : BASE_URL;

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

			if (tokenStorage == null) {
			         this.tokenStorage = new NullTokenStorage();
			}
		}



		private void getToken() {
			var client = new RestClient(this.baseURL);

			client.Authenticator = new HttpBasicAuthenticator(this.userId, this.secret);

			var request = new RestRequest(this.tokenURL, Method.POST);
			var response = client.Execute < TokenPostRspVO > (request);
			if (response.ErrorException != null) {
				Console.Out.Write(response.ErrorException);
				var message = response.Content;
				var ppException = new ApplicationException(message, response.ErrorException);
				throw ppException;
			}

			this.tokenObj = new TokenEntity(response.Content); // raw content as string

			Console.Out.Write(tokenObj.getJson());
		}

		public PaymentPostRspVO postPayment(PaymentPostReqVO data) {
			var request = new RestRequest(this.postPaymentURL, Method.POST);
			request.AddObject(data);
			return this.Execute < PaymentPostRspVO > (request);
		}
		public AtmVAccountPostRspVO postPaymentAtmVA(AtmVAccountPostReqVO data) {
			var request = new RestRequest(this.postPaymentAtmVAURL, Method.POST);
			request.AddObject(data);
			return this.Execute < AtmVAccountPostRspVO > (request);
		}
		public PaymentAuditPostRspVO postPaymentAudit(PaymentAuditPostReqVO data) {
			var request = new RestRequest(this.postPaymentAuditURL, Method.POST);
			request.AddObject(data);
			return this.Execute < PaymentAuditPostRspVO > (request);
		}
		public RefundPostRspVO postRefund(RefundPostReqVO data) {
			var request = new RestRequest(this.postRefundURL, Method.POST);
			request.AddObject(data);
			return this.Execute < RefundPostRspVO > (request);
		}
		public WithdrawPostRspVO postWithdraw(int amount) {
			var data = new WithdrawPostReqVO();
			data.amount = amount;
			var request = new RestRequest(this.postWithdrawURL, Method.POST);
			request.AddObject(data);
			return this.Execute < WithdrawPostRspVO > (request);
		}
		public PaymentGetRspVO getPayment(string orderId) {
			if (orderId.Trim() == "") {
				throw new ApplicationException("Order does not exist!");
			}

			var data = new PaymentGetReqVO(orderId);

			var request = new RestRequest(this.getPaymentURL, Method.GET);
			request.AddObject(data);
			return this.Execute < PaymentGetRspVO > (request);
		}
		public AtmBanksGetRspVO getPaymentAtmBanks() {
			var request = new RestRequest(this.getPaymentAtmBanksURL, Method.GET);
			return this.Execute < AtmBanksGetRspVO > (request);
		}
		public CardBanksGetRspVO getPaymentCardBanks() {
			var request = new RestRequest(this.getPaymentCardBanksURL, Method.GET);
			return this.Execute < CardBanksGetRspVO > (request);
		}

		public RefundGetRspVO getRefund(string refudId) {
			var request = new RestRequest(this.getRefundURL, Method.GET);
			request.AddParameter("refund_id", refudId);
			return this.Execute < RefundGetRspVO > (request);
		}

		public CheckingGetRspVO getChecking(CheckingGetReqVO data) {
			var request = new RestRequest(this.getCheckingURL, Method.GET);
			request.AddObject(data);
			return this.Execute < CheckingGetRspVO > (request);
		}
		public BalanceGetRspVO getBalance() {
			var request = new RestRequest(this.getBalanceURL, Method.GET);
			return this.Execute < BalanceGetRspVO > (request);
		}

		private TokenEntity TokenObj{
			get{
				var tokenFail = false;

        		//從 storage 取得資料
        		if (this.tokenObj == null) {
            		var str = this.tokenStorage.getTokenStr(); 
					if(str.Trim() != ""){
						this.tokenObj = new TokenEntity(str);
					}else{
						tokenFail = true;
					}
				}

				//如果沒有資料 或 token 快過期時 , 取得新的 token
				if (tokenFail ||
					this.tokenObj == null  ||
					this.tokenObj.willExpiredIn(TOKEN_EXPIRE_SEC)) {
						this.getToken();
						this.tokenStorage.saveTokenStr(this.tokenObj.getJson());
				}

				return this.tokenObj;
			}
            
        }

		private T Execute < T > (RestRequest request) where T: new() {
			var client = new RestClient();
			client.BaseUrl = new System.Uri(baseURL);

			//var tokenObj = this.getTokenObject();

			request.AddHeader("pcpay-token", this.TokenObj.getToken());

			var response = client.Execute < T > (request);

			if (response.ErrorException != null) {
				string message = response.Content;
				var ppException = new ApplicationException(message, response.ErrorException);
				throw ppException;
			}
			return response.Data;
		}
	}
}