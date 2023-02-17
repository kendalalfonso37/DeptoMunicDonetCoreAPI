using DepartamentosMunicipiosAPI.Filters;

namespace DepartamentosMunicipiosAPI.Services
{
    public interface IUriServiceHelper
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
