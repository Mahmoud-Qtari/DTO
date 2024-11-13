using CRUD2.Data;
using CRUD2.DTOs.Departments;
using CRUD2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

namespace CRUD2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DepartmentController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult getAll()
        {
            var dep = context.departments.Select
            (
                depDto => new GetDepartmentDto()
                {
                    Id = depDto.Id,
                    Name = depDto.Name,
                }
            );
            return Ok(dep);
        }

        [HttpGet("Details")]
        public IActionResult getById(int id)
        {
            var dep = context.departments.Find(id);
            if (dep is null)
            {
                return NotFound("department not found");
            }
            GetByIdDTO Depdto = new GetByIdDTO()
            {
                Id = dep.Id,
                Name = dep.Name,
            };
            return Ok(Depdto);
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateDepartment depDTO)
        {
            
            Department dep = new Department()
            {
                Name = depDTO.Name,
            };
            context.departments.Add(dep);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, UpdateDepDto depDto)
        {
            var department = context.departments.Find(id);
            if (department is null)
            {
                return NotFound("department not found");
            }
            GetByIdDTO getDepdto = new GetByIdDTO()
            {
                Id = department.Id,
                Name = department.Name,
            };

            getDepdto.Name = depDto.Name;
            context.SaveChanges();
            return Ok(getDepdto);
        }

        [HttpDelete("Remove")]
        public IActionResult Remove(int id)
        {
            var dep = context.departments.Find(id);
            if (dep is null)
            {
                return NotFound("department not found");
            }
            context.departments.Remove(dep);
            context.SaveChanges();
            RemoveDepDto depDto = new RemoveDepDto()
            {
                Name= dep.Name,
            };
            return Ok(depDto);
        }
    }
}
