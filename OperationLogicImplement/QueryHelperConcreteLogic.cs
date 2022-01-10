using System;
using System.Linq;
using System.Reflection;
using UsersTestApi.Entity;
using System.Collections.Generic;
using CustomTools;

namespace UsersTestApi.OperationLogicImplement
{
    public class QueryHelperConcreteLogic
    {
        public static IQueryable<UserItem> OrderByAttributeReflectQuery(IQueryable<UserItem> _argIQueryable, string _attribueSort, string _descParam)
        {
            if (_attribueSort == null)
                return _argIQueryable;

            Type currentType = typeof(UserItem);
            PropertyInfo currentProperty = currentType.GetProperty(_attribueSort);
            if (currentProperty == null)
                return _argIQueryable;

            Func<UserItem, object> funcExprArg = a => currentProperty.GetValue(a);

            IQueryable<UserItem> orderedBuffer = QueryToolHelper.GetOrderByParamQuery(_argIQueryable, funcExprArg, _descParam);

            return orderedBuffer;

            //.ThenByDescending(a => a.GetType().GetProperty("Id").GetValue(a, null)).ToList();
        }

        public static IEnumerable<T> OrderByAttributeReflectIEnum<T>(IEnumerable<T> _argIQueryable, string _attribueSort, string _descParam)
        {
            Type currentType = typeof(T);
            PropertyInfo currentProperty = currentType.GetProperty(_attribueSort);
            if (currentProperty == null)
                return _argIQueryable;

            Func<T, object> orderFunc = (a => currentProperty.GetValue(a));

            var orderedBuffer = QueryToolHelper.GetOrderByParamIEnum(_argIQueryable, orderFunc, _descParam);

            return orderedBuffer;

            //.ThenByDescending(a => a.GetType().GetProperty("Id").GetValue(a, null)).ToList();
        }
    }
}
