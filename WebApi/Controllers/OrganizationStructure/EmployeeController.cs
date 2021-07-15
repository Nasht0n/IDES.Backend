using System;
using System.Threading.Tasks;
using Application.OrganizationStructure.Departments.Commands.UpdateDepartment;
using Application.OrganizationStructure.Employees.Commands.CreateEmployee;
using Application.OrganizationStructure.Employees.Commands.DeleteEmployee;
using Application.OrganizationStructure.Employees.Queries.GetEmployeeDetails;
using Application.OrganizationStructure.Employees.Queries.GetEmployeeList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.OrganizationStructure;

namespace WebApi.Controllers.OrganizationStructure
{
    [Route("api/[controller]")]
    public class EmployeeController:BaseController
    {
        private readonly IMapper _mapper;

        public EmployeeController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<EmployeeListVm>> GetAll([FromQuery] bool isDeleted)
        {
            var query = new GetEmployeeListQuery() {IsDeleted = isDeleted};
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetailsVm>> Get([FromQuery] Guid id)
        {
            var query = new GetEmployeeDetailsQuery() {Id = id};
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
            var employeeId = await Mediator.Send(command);
            return Ok(employeeId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentDto updateDepartmentDto)
        {
            var command = _mapper.Map<UpdateDepartmentCommand>(updateDepartmentDto);
            await Mediator.Send(command);
            return NoContent();
        }

        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var command = new DeleteEmployeeCommand() {Id = id};
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
