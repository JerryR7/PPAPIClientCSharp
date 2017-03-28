using System.Collections.Generic;
using PPApiClient.ValueObject.Response;

namespace PPApiClient.ValueObjects.Response {

    /**
     * 查詢分期信用卡銀行 Request VO
     *
     * 查詢目前可使用信用卡分期的銀行資訊
     *
     * Class CardBanksGetRspVO
     * @package PPApiClient.ValueObjects.Response
     */
    public class CardBanksGetRspVO {
        /**
         * @var List<CardBanksGetRspBankVO>
         */
        public List < CardBanksGetRspBankVO > banks;
    }


}