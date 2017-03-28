namespace PPApiClient.ValueObject.Request {


   public class PaymentPostReqCARDVO {
        /**
         * 合作平台允許可分期
         *
         * @var int
         */
        public int installment;

        /**
         * 向買家收取之分期信用卡手續費
         *
         * @var float
         */
        public float rate;

        /**
         * PaymentPostReqCARDVO constructor.
         * @param $installment int
         * @param $rate float
         */
        public PaymentPostReqCARDVO(int installment, float rate) {
            this.installment = installment;
            this.rate = rate;
        }
    }
}