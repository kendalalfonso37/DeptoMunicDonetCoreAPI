using AutoMapper;
using DepartamentosMunicipiosAPI.DatabaseContexts;
using DepartamentosMunicipiosAPI.DTOs;
using DepartamentosMunicipiosAPI.Entities;
using DepartamentosMunicipiosAPI.Filters;
using DepartamentosMunicipiosAPI.Helpers;
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
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly IUriServiceHelper uriService;

        public DepartamentoController(ApplicationDbContext context, IMapper mapper, IUriServiceHelper uriService)
        {
            this.mapper = mapper;
            this.context = context;
            this.uriService = uriService;
        }

        [HttpGet(Name = "getDepartamentos")]
        public async Task<ActionResult<PagedResponse<List<DepartamentoDTO>>>> Get([FromQuery] PaginationFilter paginationFilter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

            var pagedData = await context.Departamentos.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();

            var totalRecords = await context.Departamentos.CountAsync();

            var dtos = mapper.Map<List<DepartamentoDTO>>(pagedData);

            var pagedResponse = PaginationHelper.CreatePagedResponse(dtos, validFilter, totalRecords, uriService, route);

            return Ok(pagedResponse);

            //var entidades = await context.Departamentos.ToListAsync();
            //return mapper.Map<List<DepartamentoDTO>>(entidades);
        }

        [HttpGet("{id:}", Name = "getDepartamento")]
        public async Task<ActionResult<Response<DepartamentoDTO>>> Get(int id)
        {
            var entidad = await context.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<DepartamentoDTO>(entidad);

            return Ok(new Response<DepartamentoDTO>(dto));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DepartamentoCreationDTO departamentoCreationDTO)
        {
            var entidad = mapper.Map<Departamento>(departamentoCreationDTO);
            context.Add(entidad);
            await context.SaveChangesAsync();
            var dto = mapper.Map<DepartamentoDTO>(entidad);
            var response = new Response<DepartamentoDTO>(dto);
            return new CreatedAtRouteResult("getDepartamento", new { id = entidad.Id }, response);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DepartamentoCreationDTO departamentoCreationDTO)
        {
            var entidad = mapper.Map<Departamento>(departamentoCreationDTO);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await context.Departamentos.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound();
            }
            context.Remove(new Departamento() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
