namespace PPApiClient.ValueObjects.Response {

    /**
     * 信用卡訂單查詢物件
     *
     * Class PaymentGetRspCARDVO
     * @package PPApiClient.ValueObjects.Response
     */
   public class PaymentGetRspCARDVO: IPaymentInfo {
        /**
         * 買家所選的分期期數
         *
         * @var int
         */
        public int installment;
    }
}