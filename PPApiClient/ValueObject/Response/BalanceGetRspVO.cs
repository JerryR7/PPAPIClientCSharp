namespace PPApiClient.ValueObjects.Response {

    /**
     * 查詢餘額 Response VO
     *
     * Class BalanceGetRspVO
     * @package PPApiClient.ValueObjects.Response
     */
   public class BalanceGetRspVO {
        /**
         * 總餘額
         *
         * 查詢帳戶中所有的金額
         *
         * @var int
         */
        public int all;

        /**
         * 可提領餘額
         *
         * 查詢帳戶中所有可提領的金額
         *
         * @var int
         */
        public int available;

        /**
         * 處理中餘額
         *
         * 查詢帳戶中所有提領中或其他清算中金額
         *
         * @var int
         */
        public int processing;
    }
}