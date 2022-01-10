using System;
using System.Linq;
using System.Collections.Generic;
using RepositoryTemplate.IValidationTemplates;
using UsersTestApi.Entity;
using OtherCustomTools;
using UsersTestApi.OperationLogicImplement;

namespace UsersTestRest.OperationLogicImplement.Validations
{
    public class ValidatePostUsers : IValidatorQueryableItems<UserItem>
    {
        private IQueryable<UserItem> injectiedQueryableItems;

        public const string postErrorPrefix = "Error with post: ";
        public static readonly string[] exceptionsStrings = new string[] { "User with the same name and full name already exists in DB ",
                                                                         "ID is autoincrement, and it need will null or 0" };

        private List<Action<UserItem, IResultOperation>> allCheckActionsOperations = new();

        private void FillCheckActionsFilters()
        {
            allCheckActionsOperations.Add(FilterToPost_NameExist);
            allCheckActionsOperations.Add(FilterToPost_InvalidJsonRef);
        }

        public static string GetErrorByEnum(ValidatePostErrorsEnum _argEnum)
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
                _resultOperation.SetResultFalseAndAddLog(GetErrorByEnum(ValidatePostErrorsEnum.InvalidJson));
                return false;
            }
            return true;
        }

        private void FilterToPost_NameExist(UserItem _argItemCheck, IResultOperation _argResult)
        {
            var resultName = injectiedQueryableItems.Where(d => ((d.Name + d.FullName) == (_argItemCheck.Name + _argItemCheck.FullName)));

            if (resultName.Count() != 0)
                _argResult.SetResultFalseAndAddLog(GetErrorByEnum(ValidatePostErrorsEnum.UserSameNameExist) + resultName.Count());
        }

        private void FilterToPost_InvalidJsonRef(UserItem _argItemCheck, IResultOperation _argResult)
        {
            if (_argItemCheck.Id != 0)
                _argResult.SetResultFalseAndAddLog(GetErrorByEnum(ValidatePostErrorsEnum.InvalidJson));
        }

        public IQueryable<UserItem> GetQueryableItems()
        {
            return injectiedQueryableItems;
        }

        public void SetQueryableItems(IQueryable<UserItem> _setQueryableItems)
        {
            injectiedQueryableItems = _setQueryableItems;
        }

        public ValidatePostUsers()
        {
            FillCheckActionsFilters();
        }
    }
}
