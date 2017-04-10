namespace PPApiClient.ValueObject.Request {


    public abstract class IPaymentReqVO {
        /**
         * 合作平台訂單編號，此欄位為唯一值
         *
         * 特店所建立之訂單編號不得重複
         *
         * @var string
         */
        public string order_id;

        /**
         * 訂單金額
         *
         * @var int
         */
        public int amount;

        /**
         * 合作平台訂單時間
         *
         * @var string
         */
        public string order_date;

        /**
         * 合作平台會員編號
         *
         * ```
         * 本欄位為選填，當平台為 B2B2C 的模式時，平台可以將訂單直接指定給平台下的用戶。
         * 但該平台用戶需要先與支付連的帳號做綁定。當平台用戶 ID 未綁定時系統會回應錯誤訊息
         * ```
         *
         * @var string
         */
        public string plat_userid;

        /**
         * 平台預扣金額
         *
         * ```
         * 本欄位為選填，當本欄位有值時，plat_userid 也不可為空。
         * 當有指定 plat_userid 時，平台可用此欄位將部分訂單金額撥給平台
         * ```
         *
         * @var int
         */
        public int plat_deduct_amt;

        /**
         * 商品名稱，會出現在畫面上供買家確認
         *
         * @var string
         */
        public string item_name;

        /**
         * 商品連結
         *
         * @var string
         */
        public string item_url;

        public string pay_type;
    }
}