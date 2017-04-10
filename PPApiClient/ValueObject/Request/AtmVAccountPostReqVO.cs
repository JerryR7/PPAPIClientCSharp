namespace PPApiClient.ValueObject.Request {

    /**
     * 取得 ATM 虛擬帳號 Request VO
     *
     * Class AtmVAccountPostReqVO
     * @package PCPayCommon\ValueObjects\PrvtApi\Request
     */
   public class AtmVAccountPostReqVO: IPaymentReqVO {
        /**
         * 消費者產生虛擬帳號後可至 ATM 付款之期 限,期限需小於 5 天
         *
         * @var int
         */
        public int expire_days;

        /**
         * 要產生那家銀行的虛擬帳號,可用查詢虛擬帳 號銀行 API 取得可用之行銀代碼
         *
         * @var string
         */
        public string atm_bank;

        /**
         * 合作平台買家會員帳號
         * 若有選填此欄位，可提供支付連記錄會員付款時之相關功能。使用此欄位時，請務必注意此帳號不可共用，不同買家需傳送不同帳號。
         * @var string
         */
        public string buyer_id;

        /**
         * 買家email
         * 若有選填此欄位，付款時支付連也會另外寄信通知此email付款是否成功
         * @var string
         */
        public string buyer_email;
    }
}