namespace PPApiClient.ValueObject.Request {


   public class PaymentPostReqATMVO {
        /**
         * PaymentPostReqATMVO constructor.
         * @param int expire_days atm expire days
         */
        public PaymentPostReqATMVO(int expire_days) {
            this.expire_days = expire_days;
        }

        /**
         * 消費者產生虛擬帳號後可至 ATM 付款貸期限，期限需小於 5 天
         *
         * @var int
         */
        public int expire_days;
    }
}