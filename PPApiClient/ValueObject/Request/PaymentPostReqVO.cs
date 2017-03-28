using System.Collections.Generic;

namespace PPApiClient.ValueObject.Request {

       public class PaymentPostReqVO: IPaymentReqVO {
            /**
             * ATM 訂單進階設定物件
             *
             * @var PaymentPostReqATMVO
             */
            public PaymentPostReqATMVO atm_info;

            /**
             * 信用卡訂單進階設定物件
             *
             * @var List < PaymentPostReqCARDVO >
             */
            public List < PaymentPostReqCARDVO > card_info;
        }
}