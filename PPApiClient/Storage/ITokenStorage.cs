namespace PPApiClient.Storage {
    public interface ITokenStorage {
         /// <summary>
         /// get jsonlized token from storage
         /// </summary>
         /// <returns>jsonlized token from storage</returns>
        string getTokenStr();

        /// <summary>
        /// save jsonlized token to storage
        /// </summary>
        /// <param name="token">true while success, false when fail</param>
        bool saveTokenStr(string token);
    }
}