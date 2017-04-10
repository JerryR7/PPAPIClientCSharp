using System.Collections.Generic;

namespace PPApiClient.ValueObjects.Response {

    /**
     * 查詢可用 ATM 虛擬帳號銀行 Response VO
     *
     * Class AtmBanksGetRspVO
     * @package PPApiClient\ValueObjects\Response
     */
   public class AtmBanksGetRspVO {
        /**
         * 銀行物件陣型
         *
         * @var array[\PPApiClient\ValueObjects\Response\QueryAtmBankVO]
         */
        public List < AtmBanksGetRspBankVO > banks;
    }
}