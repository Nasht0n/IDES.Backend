using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.OrganizationStructure.Departments.Commands.CreateDepartment;
using Application.OrganizationStructure.Departments.Commands.DeleteDepartment;
using Application.OrganizationStructure.Departments.Commands.UpdateDepartment;
using Application.OrganizationStructure.Departments.Queries.GetDepartmentDetails;
using Application.OrganizationStructure.Departments.Queries.GetDepartmentList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.OrganizationStructure;

namespace WebApi.Controllers.OrganizationStructure
{
    [Route("api/[controller]")]
    public class DepartmentController:BaseController
    {
        private readonly IMapper _mapper;

        public DepartmentController(IMapper mapper) => _mapper = mapper;
        
        [HttpGet]
        public async Task<ActionResult<DepartmentListVm>> GetAll(bool isDeleted)
        {
            var query = new GetDepartmentListQuery() {IsDeleted = isDeleted};
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDetailsVm>> Get(Guid id)
        {
            var query = new GetDepartmentDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDepartmentDto createDepartmentDto)
        {
            var command = _mapper.Map<CreateDepartmentCommand>(createDepartmentDto);
            var departmentId = await Mediator.Send(command);
            return Ok(departmentId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentDto updateDepartmentDto)
        {
            var command = _mapper.Map<UpdateDepartmentCommand>(updateDepartmentDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteDepartmentCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
