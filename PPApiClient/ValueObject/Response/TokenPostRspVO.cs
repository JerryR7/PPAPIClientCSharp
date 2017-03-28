using System;

namespace PPApiClient.ValueObjects.Response {

   public class TokenPostRspVO {
        public string token;
        public int expired_in;
        public int expired_timestamp;
    }
}