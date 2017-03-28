namespace PPApiClient.ValueObject.Request {

    /**
     * 提領 Request VO
     *
     * 合作平台透過支付連 API 將可提領之餘額提領至合作平台在支付連系統設定之銀行帳戶
     *
     * Class WithdrawPostReqVO
     * @package PCPayCommon.ValueObjects.Request
     */
   public class WithdrawPostReqVO {
        /**
         * 合作平台欲提領之金額
         *
         * @var int
         */
        public int amount;
    }


}