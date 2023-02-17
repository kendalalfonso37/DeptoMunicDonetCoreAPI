using DepartamentosMunicipiosAPI.Filters;
using Microsoft.AspNetCore.WebUtilities;

namespace DepartamentosMunicipiosAPI.Services
{
    public class UriServiceHelper : IUriServiceHelper
    {
        private readonly string _baseUri;

        public UriServiceHelper(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            var _endpointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(_endpointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
