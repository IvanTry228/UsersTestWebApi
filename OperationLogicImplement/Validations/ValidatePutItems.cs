using System;
using System.Collections.Generic;
using System.Linq;
using UsersTestApi.Entity;
using RepositoryTemplate.IValidationTemplates;
using OtherCustomTools;
using UsersTestApi.OperationLogicImplement;

namespace UsersTestRest.OperationLogicImplement.Validations
{
    public class ValidatePutItems : IValidatorQueryableItems<UserItem>
    {
        private IQueryable<UserItem> injectiedQueryableItems;

        public const string postErrorPrefix = "Error with post: ";
        public static readonly string[] exceptionsStrings = new string[] { "User with this id not found",
                                                                         "ID is autoincrement, and it need will null or 0" };

        private List<Action<UserItem, IResultOperation>> allCheckActionsOperations = new();

        private void FillCheckActionsFilters()
        {
            allCheckActionsOperations.Add(FilterToPut_IdSeach);
        }

        public static string GetErrorByEnum(ValidatePutErrorsEnum _argEnum)
        {
            return exceptionsStrings[(int)_argEnum];
        }

        public bool IsValidatedItem(UserItem _argItemCheck, IResultOperation _argIResult)
        {
            _argIResult.SetNexPrefixStringFail(postErrorPrefix + IResultOperation.constResultFail);

            if (FilterCheckNullRef(_argItemCheck, _argIResult))
                foreach (var item in allCheckActionsOperations)
                {
                    item.Invoke(_argItemCheck, _argIResult);
                }

            bool resultSuccess = _argIResult.IsResultSuccess();

            return resultSuccess;
        }

        private bool FilterCheckNullRef(UserItem _argItemCheck, IResultOperation _resultOperation)
        {
            if (_argItemCheck == null)
            {
                _resultOperation.SetResultFalseAndAddLog(GetErrorByEnum(ValidatePutErrorsEnum.InvalidJson));
                return false;
            }
            return true;
        }

        private void FilterToPut_IdSeach(UserItem _argItemCheck, IResultOperation _argResult)
        {
            int seachId = _argItemCheck.Id;

            var seachIdQuery = injectiedQueryableItems.Where(user => (user.Id == seachId));

            if (seachIdQuery.Count() == 0)
                _argResult.SetResultFalseAndAddLog(GetErrorByEnum(ValidatePutErrorsEnum.UserIsIdNotFound) + seachIdQuery.Count());
            else if(seachIdQuery.Count() != 1)
                _argResult.SetResultFalseAndAddLog(GetErrorByEnum(ValidatePutErrorsEnum.OtherCase) + seachIdQuery.Count());
        }

        public IQueryable<UserItem> GetQueryableItems()
        {
            return injectiedQueryableItems;
        }

        public void SetQueryableItems(IQueryable<UserItem> _setQueryableItems)
        {
            injectiedQueryableItems = _setQueryableItems;
        }

        public ValidatePutItems()
        {
            FillCheckActionsFilters();
        }
    }
}
