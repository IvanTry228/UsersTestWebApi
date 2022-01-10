using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CustomTools;
using UsersTestApi.Entity;

namespace UsersTestApi.OperationLogicImplement
{
    public class QueryHelperConcreteLogic
    {
        public static void CallSortingTest()
        {
            //OrderByAttributeReflect<DogItem>(null, "Color", "desc");
            //List<DogItem> fastDogItems = new List<DogItem>();
            //var fastDogItems = DogsFastFakeFiller.GetRandomElementsDogList(30);
            //fastDogItems = OrderByAttributeReflect(fastDogItems, "Color", "asc").ToList();

            //DogsFastFakeFiller.TestCallLogDogItems(fastDogItems);
        }

        public static IQueryable<UserItem> OrderByAttributeReflectQuery(IQueryable<UserItem> _argIQueryable, string _attribueSort, string _descParam) //where T : DogItem
        {
            if (_attribueSort == null)
                return _argIQueryable;

            Type currentType = typeof(UserItem);
            PropertyInfo currentProperty = currentType.GetProperty(_attribueSort);
            if (currentProperty == null)
                return _argIQueryable;

            //Expression<Func<DogItem, object>> expressArg = a => currentProperty.GetValue(a);
            Func<UserItem, object> funcExprArg = a => currentProperty.GetValue(a);

            //var orderedBuffer = QueryToolHelper.GetOrderByParamNew(_argIQueryable, orderFunc, _descParam);
            IQueryable<UserItem> orderedBuffer = QueryToolHelper.GetOrderByParamNewQuer(_argIQueryable, funcExprArg, _descParam);

            return orderedBuffer;

            //.ThenByDescending(a => a.GetType().GetProperty("Id").GetValue(a, null)).ToList();
        }

        public static IEnumerable<T> OrderByAttributeReflectIEnum<T>(IEnumerable<T> _argIQueryable, string _attribueSort, string _descParam) //where T : DogItem
        {
            Type currentType = typeof(T);
            PropertyInfo currentProperty = currentType.GetProperty(_attribueSort);
            if (currentProperty == null)
                return _argIQueryable;

            Func<T, object> orderFunc = (a => currentProperty.GetValue(a));

            var orderedBuffer = QueryToolHelper.GetOrderByParamNew(_argIQueryable, orderFunc, _descParam);

            return orderedBuffer;

            //.ThenByDescending(a => a.GetType().GetProperty("Id").GetValue(a, null)).ToList();
        }
    }
}
