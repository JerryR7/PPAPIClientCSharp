namespace PPApiClient.ValueObjects.Response {

   public class PaymentPostRspVO {
        /**
         * 合作平台訂單編號
         *
         * @var string
         */
        public string order_id;

        /**
         * 回傳一組 URL 以供合作平台將消費者導頁至 支付連相應付款頁面。
         *
         * @var string
         */
        public string payment_url;
    }
}