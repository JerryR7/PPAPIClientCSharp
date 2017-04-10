namespace PPApiClient.ValueObjects.Response {

    /**
     * 提領 Response VO
     *
     * Class CreateWithdrawRspVO
     * @package PPApiClient.ValueObjects.Response
     */
   public class WithdrawPostRspVO {
        /**
         * 提領金額
         * @var int
         */
        public int withdraw_amount;
        /**
         * 跨行提領手續費
         * 該次提領所需負擔的跨行提領手續費
         * @var int
         */
        public int transfer_fee;
        /**
         * 銀行代碼
         * @var string
         */
        public string bank_id;
        /**
         * 銀行帳號
         * @var string
         */
        public string bank_account;
    }
}