namespace PPApiClient.ValueObjects.Response {

    /**
     * 取得 ATM 虛擬帳號 Response VO
     *
     * Class AtmVAccountPostRspVO
     * @package PPApiClient.ValueObjects.Response
     */
   public class AtmVAccountPostRspVO {
        /**
         * 訂單編號
         *
         * @var string
         */
        public string order_id;

        /**
         * ATM 虛擬帳號
         *
         * @var string
         */
        public string virtual_account;

        /**
         * 銀行代碼
         *
         * @var int
         */
        public int bank_id;

        /**
         * 失效日期
         *
         * @var string
         */
        public string expire_date;
    }
}