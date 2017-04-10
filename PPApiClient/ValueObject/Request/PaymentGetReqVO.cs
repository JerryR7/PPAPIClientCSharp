namespace PPApiClient.ValueObject.Request {

    /**
     * 查詢合作平台於支付連系統建立之訂單狀態,不同交易類型訂單將有額外不同訂單訊息 Request VO
     *
     * Class PaymentGetReqVO
     * @package PCPayCommon.ValueObjects.Request
     */
   public class PaymentGetReqVO {
       public PaymentGetReqVO(string orderid){
           this.order_id = orderid;
       }
        /**
         * 合作平台訂單編號
         *
         * @var string
         */
        public string order_id;
    }
}