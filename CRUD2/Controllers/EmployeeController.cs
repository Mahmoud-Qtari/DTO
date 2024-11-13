using CRUD2.Data;
using CRUD2.DTOs.Employees;
using CRUD2.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmployeeController(ApplicationDbContext  context)
        {
            this.context = context;
        }
        [HttpGet("GetAll")]
        public IActionResult getAll()
        {
            var emplyees = context.employeees.ToList();
            var empsDto = emplyees.Adapt<IEnumerable<GetEmployeeDto>>();
            return Ok(empsDto);
        }

        [HttpGet("Details")]
        public IActionResult getById(int id)
        {
            var employee = context.employeees.Find(id);
            if(employee is null)
            {
                return NotFound("employee not found");
            }
            var EmpDto = employee.Adapt<GetEmployeeById>();
            return Ok(EmpDto);
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateEmployeeDTO empDto)
        {
            var employee = empDto.Adapt<Employeee>();
            context.employeees.Add(employee);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(int id,UpdateEmpDto empDtoNew)
        {
            var employee = context.employeees.Find(id);
            if (employee is null)
            {
                return NotFound("employee not found");
            }
            var mpDto = employee.Adapt<GetEmployeeById>();
            mpDto.Name = empDtoNew.Name;
            mpDto.Age= empDtoNew.Age;
            mpDto.DepartmentId = empDtoNew.DepartmentId;

            context.SaveChanges();
            return Ok(mpDto);
        }

        [HttpDelete("Remove")]
        public IActionResult Remove(int id)
        {
            var employee = context.employeees.Find(id);
            if (employee is null)
            {
                return NotFound("employee not found");
            }
            var EmpDto = employee.Adapt<RemoveEmpDto>();
            context.employeees.Remove(employee);
            context.SaveChanges();
            return Ok(EmpDto);
        }
    }
}
