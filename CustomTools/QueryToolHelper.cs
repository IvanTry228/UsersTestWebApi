using System;
using System.Linq;
using System.Collections.Generic;

namespace CustomTools
{
    public static class QueryToolHelper
    {
        public const string paramOrderDesc = "desc";
        public const string paramOrderAsc = "asc";

        private const int defaultOffsetPagination = 1;

        public static IQueryable<T> SelectWithLimits<T>(IQueryable<T> _argIQueryable, int _argLimit)
        {
            var queryResult = _argIQueryable.Take(_argLimit);
            return queryResult;
        }

        public static IQueryable<T> PaginationPages<T>(IQueryable<T> _argIQueryable, int _currentPage, int _countItemsOnPages)
        {
            if (_currentPage <= 0)
                _currentPage = defaultOffsetPagination;

            var queryResult = _argIQueryable
              .Skip(_countItemsOnPages * (_currentPage - defaultOffsetPagination))
              .Take(_countItemsOnPages);

            return queryResult;
        }

        public static IQueryable<T> GetOrderByParamQuery<T, Tkey>(IQueryable<T> _argIQueryable, Func<T, Tkey> _argExpression, string _argParamDescAsc)
        {
            IEnumerable<T> castIEnumerable = _argIQueryable.AsEnumerable();

            if (_argParamDescAsc == paramOrderDesc)
                castIEnumerable = castIEnumerable.OrderByDescending(_argExpression);
            if (_argParamDescAsc == paramOrderAsc)
                castIEnumerable =  castIEnumerable.OrderBy(_argExpression);

            IQueryable<T> castToQuery = castIEnumerable.AsQueryable();

            return castToQuery;
        }

        public static IEnumerable<T> GetOrderByParamIEnum<T, Tkey>(IEnumerable<T> _argIQueryable, Func<T, Tkey> _argExpression, string _argParamDescAsc)
        {
            if (_argParamDescAsc == paramOrderDesc)
                return _argIQueryable.OrderByDescending(_argExpression);
            if (_argParamDescAsc == paramOrderAsc)
                return _argIQueryable.OrderBy(_argExpression);

            return _argIQueryable;
        }
    }
}
