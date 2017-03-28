namespace PPApiClient.ValueObject.Request {

    /**
     * 建立退款 Request VO
     *
     * 合作平台請求支付連 API 做退款動作,同一筆訂單可做多次退款,每筆退款+每筆退款 手續費不得超過訂單金額。
     *
     * Class RefundPostReqVO
     * @package PCPayCommon.ValueObjects.Request
     */
   public class RefundPostReqVO {
        /**
         * 合作平台欲退款原訂單編號
         *
         * @var string
         */
        public string order_id;

        /**
         * 合作平台退款編號
         *
         * @var string
         */
        public string refund_id;

        /**
         * 退款金額,需小於等於訂單 TradeAmount
         *
         * @var int
         */
        public int trade_amount;

        /**
         * 跨行轉帳手續費
         * 值須為 Y 或 N .Y:由串接廠商吸收跨行轉帳手續費。 .N:由使用者自行負擔跨行轉帳手續費。
         *
         * @var string
         */
        public string cover_transfee;


        /**
         * 使用者身份字號或是公司統編
         * 
         * 當使用者使用atm 退款方式時，需要身份證字號或統編才能夠正確的退款。串接商廠需要提供買家原匯款帳戶之正確的身份證字號。
         * 如串接商廠無法提供時，會回傳一個導頁URL，請串接廠商將買家導頁至該URL以收集使用者身份字號或是公司統編。
         * @var string
         */
        public string buyer_id;

        /**
         * 返回 URL
         *
         * 當使用者需要輸入ATM退款資訊時，需要有一返回 URL 以便填寫完之後返回串接廠商的頁面
         * @var string
         */
        public string return_url;
    }
}