using OtherCustomTools;

namespace RepositoryTemplate
{
    public class ResultOperation : IResultOperation
    {
        private bool isResult;
        private string resultStringLog;

        private string prefixSuccess = IResultOperation.constResultSuccess;
        private string prefixFail = IResultOperation.constResultSuccess;

        public string GetResultStringLog()
        {
            return GetPrefixString() + resultStringLog;
        }

        public bool IsResultSuccess()
        {
            return isResult;
        }

        public void SetResultFalseAndAddLog(string argResultDescription)
        {
            isResult = false;
            resultStringLog += argResultDescription;
        }

        public void ResetOperationSuccess()
        {
            ResetOperationSuccess(true);
        }

        public void ResetOperationSuccess(bool _isSuccess)
        {
            isResult = _isSuccess;
            resultStringLog = "";
        }

        public ResultOperation(bool isDefaultSuccess)
        {
            ResetOperationSuccess(isDefaultSuccess);
        }

        public void SetForciblyTextLog(string _argNExText)
        {
            resultStringLog = _argNExText;
        }

        public string GetPrefixString()
        {
            if (IsResultSuccess())
                return prefixSuccess;
            else
                return prefixFail;
        }

        public void SetNexPrefixStringSuccess(string _argNewPrefix)
        {
            prefixSuccess = _argNewPrefix;
        }

        public void SetNexPrefixStringFail(string _argNewPrefix)
        {
            prefixFail = _argNewPrefix;
        }

        public ResultOperation()
        {
            ResetOperationSuccess();
        }
    }
}
