namespace PPApiClient.ValueObject.Request {

    /**
     * 訂單審單
     *
     * 合作平台如果有設定需要審單，訂單在滿足審單條件時訂單狀態並不會直接變為”成功”，而是進入 “平台審單中”的狀態。此時平台需要呼叫本API來決定是否接受客人的訂單
     *
     * Class AuditPostReqVO
     * @package PPApiClient.ValueObject.Request
     */
   public class PaymentAuditPostReqVO {
        /**
         * 合作平台訂單編號, 此欄位為唯一值。特店所建立之訂單編號不得重複。
         *
         * @var string
         */
        public string order_id;

        /**
         * PASS：訂單過單
         * DENY：訂單取消
         *
         * @var string
         */
        public string status;
    }
}