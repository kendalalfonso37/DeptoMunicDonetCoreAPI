using AutoMapper;
using DepartamentosMunicipiosAPI.DTOs;
using DepartamentosMunicipiosAPI.Filters;
using DepartamentosMunicipiosAPI.Helpers;
using DepartamentosMunicipiosAPI.Mappers;
using DepartamentosMunicipiosAPI.Repositories;
using DepartamentosMunicipiosAPI.Services;
using DepartamentosMunicipiosAPI.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace DepartamentosMunicipiosAPI.Controllers
{
    [Route("api/v1/municipios")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly MunicipioMapper _mapper;
        private readonly IMunicipioRepository _repository;
        private readonly IUriServiceHelper _uriServiceHelper;
        public MunicipioController(IMunicipioRepository repository, IMapper mapper, IUriServiceHelper uriServiceHelper)
        {
            this._mapper = new MunicipioMapper(mapper);
            this._repository = repository;
            this._uriServiceHelper = uriServiceHelper;
        }

        [HttpGet(Name = "getMunicipios")]
        public async Task<ActionResult<PagedResponse<List<MunicipioDTO>>>> Get([FromQuery] PaginationFilter paginationFilter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

            var pagedData = await _repository.GetPagedList((validFilter.PageNumber - 1) * validFilter.PageSize, validFilter.PageSize);

            var totalRecords = await _repository.Count();

            var dtos = _mapper.GetListDTO(pagedData);
            var pagedResponse = PaginationHelper.CreatePagedResponse(pagedData, validFilter, totalRecords, _uriServiceHelper, route);
            return Ok(pagedResponse);
        }

    }
}
