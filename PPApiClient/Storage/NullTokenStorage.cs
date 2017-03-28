using System;

namespace PPApiClient.Storage
{
    public class NullTokenStorage : ITokenStorage
    {
        private string tokenStr;
        string ITokenStorage.getTokenStr()
        {
            return tokenStr;
        }

        bool ITokenStorage.saveTokenStr(string token)
        {
            this.tokenStr = token;

            return true;
        }
    }
}