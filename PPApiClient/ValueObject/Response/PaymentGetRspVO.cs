namespace PPApiClient.ValueObjects.Response {

    /**
     * 查詢合作平台於支付連系統建立之訂單狀態,不同交易類型訂單將有額外不同訂單訊息 Response VO
     *
     * Class QueryPaymentRspVO
     * @package PPApiClient.ValueObjects.Response
     */
   public class PaymentGetRspVO {
        /**
         * 合作平台訂單編號
         *
         * @var string
         */
        public string order_id;

        /**
         * 訂單金額，API 所帶入之金額
         *
         * @var int
         */
        public int amount;

        /**
         * 付款方式
         * @var string
         */
        public string pay_type;

        /**
         * 買家所支付的金額
         *
         * @var int
         */
        public int total_amount;

        /**
         * 平台可以得到的金額
         *
         * platform_amount = total_amount - pp_fee
         *
         * @var int
         */
        public int platform_amount;

        /**
         * 支付連手續費，交易時所收取之服務費
         *
         * @var int
         */
        public int pp_fee;

        /**
         * 支付連訂單建立時間
         *
         * @var string
         */
        public string create_date;

        /**
         * 支付連訂單交易完成時間
         *
         * @var string
         */
        public string pay_date;

        /**
         * 訂單失敗時間
         *
         * * 不會與 pay_date 同時存在。
         * * 當訂單取消、過期、自行審單逾期或其他的因 素造成訂單失敗時的時間訂單
         *
         * @var string
         */
        public string fail_date;

        /**
         * 訂單狀態
         *
         * * 交易完成：S
         * * 交易失敗：F
         * * 交易等待中：W (自行審單中、支付連審單中、ATM等待繳款中)
         *
         * @var string
         */
        public string status;

        /**
         * 各類交易類別訂單相應物件
         *
         * @var IPaymentInfo
         */
        public IPaymentInfo payment_info;

        /**
         * 轉可提領日
         * @var string
         */
        public string available_date;
    }
}