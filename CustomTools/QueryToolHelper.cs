using UsersTestApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace CustomTools
{
    public static class QueryToolHelper
    {
        public const string paramOrderDesc = "desc";
        public const string paramOrderAsc = "asc";

        private const int defaultOffset = 1;

        public static IQueryable<T> SelectWithLimits<T>(IQueryable<T> _argIQueryable, int _argLimit)
        {
            var queryResult = _argIQueryable.Take(_argLimit);
            return queryResult;
        }

        public static IQueryable<T> PaginationPages<T>(IQueryable<T> _argIQueryable, int _currentPage, int _countItemsOnPages)
        {
            if (_currentPage <= 0)
                _currentPage = defaultOffset;

            var queryResult = _argIQueryable
              .Skip(_countItemsOnPages * (_currentPage - defaultOffset))
              .Take(_countItemsOnPages);

            return queryResult;
        }

        public static IQueryable<T> GetOrderByParamNewQuer<T, Tkey>(IQueryable<T> _argIQueryable, Func<T, Tkey> _argExpression, string _argParamDescAsc)
        {
            IEnumerable<T> castIEnumerable = _argIQueryable.AsEnumerable();

            if (_argParamDescAsc == paramOrderDesc)
                castIEnumerable = castIEnumerable.OrderByDescending(_argExpression);
            if (_argParamDescAsc == paramOrderAsc)
                castIEnumerable =  castIEnumerable.OrderBy(_argExpression);

            IQueryable<T> castToQuery = castIEnumerable.AsQueryable();

            return castToQuery;
        }

        public static IEnumerable<T> GetOrderByParamNew<T, Tkey>(IEnumerable<T> _argIQueryable, Func<T, Tkey> _argExpression, string _argParamDescAsc)
        {
            if (_argParamDescAsc == paramOrderDesc)
                return _argIQueryable.OrderByDescending(_argExpression);
            if (_argParamDescAsc == paramOrderAsc)
                return _argIQueryable.OrderBy(_argExpression);

            return _argIQueryable;
        }

        public static IQueryable<T> GetOrderByParam<T, Tkey>(IQueryable<T> _argIQueryable, Expression<Func<T, Tkey>> _argExpression, string _argParamDescAsc)
        {
            if (_argParamDescAsc== paramOrderDesc)
                return _argIQueryable.OrderByDescending(_argExpression);
            if (_argParamDescAsc == paramOrderAsc)
                return _argIQueryable.OrderBy(_argExpression);

            return _argIQueryable;
        }

        //private void ApplySort(ref IQueryable<DogItem> owners, string orderByQueryString)
        //{
        //    if (!owners.Any())
        //        return;
        //    if (string.IsNullOrWhiteSpace(orderByQueryString))
        //    {
        //        owners = owners.OrderBy(x => x.Name);
        //        return;
        //    }
        //    var orderParams = orderByQueryString.Trim().Split(',');
        //    var propertyInfos = typeof(DogItem).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    var orderQueryBuilder = new StringBuilder();
        //    foreach (var param in orderParams)
        //    {
        //        if (string.IsNullOrWhiteSpace(param))
        //            continue;
        //        var propertyFromQueryName = param.Split(" ")[0];
        //        var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
        //        if (objectProperty == null)
        //            continue;
        //        var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
        //        orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
        //    }
        //    var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
        //    if (string.IsNullOrWhiteSpace(orderQuery))
        //    {
        //        owners = owners.OrderBy(x => x.Name);
        //        return;
        //    }
        //    owners = owners.OrderBy(orderQuery);
        //}
    }
}
