namespace PPApiClient.ValueObjects.Response {

    /**
     * ATM 訂單查詢物件
     *
     * Class PaymentGetRspATMVO
     * @package PPApiClient\ValueObjects\Response
     */
   public class PaymentGetRspATMVO: IPaymentInfo {
        /**
         * ATM 虛擬帳號
         *
         * @var string
         */
        public string virtual_account;

        /**
         * 虛擬帳號所屬銀行代碼
         *
         * @var string
         */
        public string bank_code;

        /**
         * 虛擬帳號過期時間
         *
         * @var string
         */
        public string expire_date;
    }
}