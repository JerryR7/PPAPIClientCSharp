using System;

namespace PPApiClient.Storage
{
    public class FileTokenStorage : ITokenStorage
    {
        string path;
        public FileTokenStorage(string filepath){
            this.path = filepath;
        }

        string ITokenStorage.getTokenStr()
        {
            if(!System.IO.File.Exists(this.path)){
                throw new ApplicationException("token file not exists:" + this.path);
            }

            return System.IO.File.ReadAllText(this.path);
        }

        bool ITokenStorage.saveTokenStr(string token)
        {
            System.IO.File.WriteAllText(this.path, token);
            return true;
        }
    }
}