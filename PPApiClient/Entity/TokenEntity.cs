using System;
using PPApiClient.ValueObjects.Response;
using RestSharp;

namespace PPApiClient.Entity {

    public class TokenEntity{

        public TokenPostRspVO tokenObj;
        private string tokenStr;
        public TokenEntity(string tokenStr) {
            this.tokenStr = tokenStr;
            var json = new RestSharp.Deserializers.JsonDeserializer();
            var rsp = new RestResponse();
            this.tokenObj = json.Deserialize<TokenPostRspVO>(rsp);
        }

        public string getToken() {
            return this.tokenObj.token;
        }

        public bool willExpiredIn(int seconds) {
            return (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds > this.tokenObj.expired_timestamp;
        }
        public string getJson() {
            return this.tokenStr;
        }

        
        public int getExpireTimestamp() {
            return this.tokenObj.expired_timestamp;
        }
    }

    class TokenException : Exception {

    }
}