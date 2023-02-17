using AutoMapper;
using DepartamentosMunicipiosAPI.DatabaseContexts;
using DepartamentosMunicipiosAPI.DTOs;
using DepartamentosMunicipiosAPI.Entities;
using DepartamentosMunicipiosAPI.Filters;
using DepartamentosMunicipiosAPI.Helpers;
using DepartamentosMunicipiosAPI.Mappers;
using DepartamentosMunicipiosAPI.Repositories;
using DepartamentosMunicipiosAPI.Services;
using DepartamentosMunicipiosAPI.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DepartamentosMunicipiosAPI.Controllers
{
    [Route("api/v1/departamentos")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly DepartamentoMapper _mapper;
        private readonly IDepartamentoRepository _repository;
        private readonly IUriServiceHelper _uriService;

        public DepartamentoController(IDepartamentoRepository repository, IMapper mapper, IUriServiceHelper uriService)
        {
            this._mapper = new DepartamentoMapper(mapper);
            this._repository = repository;
            this._uriService = uriService;
        }

        [HttpGet(Name = "getDepartamentos")]
        public async Task<ActionResult<PagedResponse<List<DepartamentoDTO>>>> Get([FromQuery] PaginationFilter paginationFilter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

            var pagedData = await _repository.GetPagedList((validFilter.PageNumber - 1) * validFilter.PageSize, validFilter.PageSize);

            var totalRecords = await _repository.Count();

            var dtos = _mapper.getListDTO(pagedData);

            var pagedResponse = PaginationHelper.CreatePagedResponse(dtos, validFilter, totalRecords, _uriService, route);

            return Ok(pagedResponse);
        }

        [HttpGet("{id:}", Name = "getDepartamento")]
        public async Task<ActionResult<Response<DepartamentoDTO>>> Get(int id)
        {
            var entidad = await _repository.GetById(id);
            if (entidad == null)
            {
                return NotFound();
            }

            var dto = _mapper.getDTO(entidad);

            return Ok(new Response<DepartamentoDTO>(dto));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DepartamentoCreationDTO departamentoCreationDTO)
        {
            var entidad = _mapper.getEntity(departamentoCreationDTO);
            await _repository.Insert(entidad);

            var dto = _mapper.getDTO(entidad);
            var response = new Response<DepartamentoDTO>(dto);
            return new CreatedAtRouteResult("getDepartamento", new { id = entidad.Id }, response);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DepartamentoCreationDTO departamentoCreationDTO)
        {
            var entidad = _mapper.getEntity(departamentoCreationDTO);
            entidad.Id = id;
            await _repository.Update(entidad);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _repository.GetById(id);
            if (exists != null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
