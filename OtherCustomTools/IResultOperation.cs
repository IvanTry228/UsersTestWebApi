using System;

namespace OtherCustomTools
{
    public interface IResultOperation
    {
        public const string constResultSuccess = "Success";
        public const string constResultFail = "Fail";

        bool IsResultSuccess();

        void SetResultFalseAndAddLog(string _argResultDescription);

        string GetResultStringLog();

        void ResetOperationSuccess();

        void ResetOperationSuccess(bool _isSuccess);

        void SetForciblyTextLog(string _argNewText);

        void SetNexPrefixStringSuccess(string _argNewPrefix);

        void SetNexPrefixStringFail(string _argNewPrefix);

        string GetPrefixString();
    }
}
