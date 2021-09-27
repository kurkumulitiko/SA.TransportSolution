using SA.Transport.Core.Application.Common.Filters;
using SA.Transport.Core.Application.Common.Paging;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace SA.Transport.Infrastructure.Database.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> TakePage<T>(this IQueryable<T> source, PageRequest pageRequest, out PageResponse pageResponse)
        {
            if (pageRequest == null)
            {
                pageRequest = new PageRequest();
            }

            var ResultQuerable = source.Skip((pageRequest.PageNumber - 1) * pageRequest.PageSize)
                                       .Take(pageRequest.PageSize);

            pageResponse = new PageResponse
            {
                CurrentPage = pageRequest.PageNumber,
                PageSize = pageRequest.PageSize,
                TotalCount = source.Count()
            };

            return ResultQuerable;
        }

        public static IQueryable<Core.Domain.Model.Transport> ApplyFilterParameters(this IQueryable<Core.Domain.Model.Transport> source, TransportFilter transportFilter)
        {

            if (transportFilter == null)
            {
                return source;
            }

            if (!string.IsNullOrEmpty(transportFilter.MakeGE?.Trim()))
            {
                source = source.Where(x => x.MakeGE.StartsWith(transportFilter.MakeGE));
            }

            if (!string.IsNullOrEmpty(transportFilter.MakeEN?.Trim()))
            {
                source = source.Where(x => x.MakeEN.ToLower().StartsWith(transportFilter.MakeEN.ToLower()));
            }

            if (!string.IsNullOrEmpty(transportFilter.ModelGE?.Trim()))
            {
                source = source.Where(x => x.ModelGE.StartsWith(transportFilter.ModelGE));
            }

            if (!string.IsNullOrEmpty(transportFilter.ModelEN?.Trim()))
            {
                source = source.Where(x => x.ModelEN.ToLower().StartsWith(transportFilter.ModelEN.ToLower()));
            }

            if (!string.IsNullOrEmpty(transportFilter.VinCode?.Trim()))
            {
                source = source.Where(x => x.VinCode.StartsWith(transportFilter.VinCode));
            }

            if (!string.IsNullOrEmpty(transportFilter.Number?.Trim()))
            {
                source = source.Where(x => x.Number.ToLower().StartsWith(transportFilter.Number.ToLower()));
            }

            return source;
        }


        public static IQueryable<T> ApplyOrderParameters<T>(this IQueryable<T> source, string orderParameters)
        {
            if (orderParameters == null || orderParameters.TrimEnd() == string.Empty) { return source; }

            var orderParams = orderParameters.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return source.OrderBy(orderQuery);

        }

    }
}
