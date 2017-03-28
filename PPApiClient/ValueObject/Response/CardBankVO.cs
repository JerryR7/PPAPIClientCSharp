namespace PPApiClient.ValueObjects.Response {

    /**
     * 信用卡銀行物件
     *
     * Class CardBankVO
     * @package PPApiClient.ValueObjects.Response
     */
   public class CardBankVO {
        /**
         * 銀行代碼
         *
         * @var 
         */
        public string bank_id;

        /**
         * 銀行名稱
         *
         * @var 
         */
        public string bank_name;

        /**
         * 可用分期期數，逗號分隔
         *
         * @var 
         */
        public string installment;
    }
}