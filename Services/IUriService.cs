using DepartamentosMunicipiosAPI.Filters;

namespace DepartamentosMunicipiosAPI.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
