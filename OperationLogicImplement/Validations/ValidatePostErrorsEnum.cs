namespace UsersTestApi.OperationLogicImplement
{
    public enum ValidatePostErrorsEnum
    { 
        UserSameNameExist,
        InvalidJson,
        OtherCase
    }

    public enum ValidatePutErrorsEnum
    {
        UserIsIdNotFound,
        InvalidJson,
        OtherCase
    }
}
