using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaEx.Entities;

namespace PruebaEx.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmployeeController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return await context.Employees.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Employee employee)
        {
            context.Add(employee);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Employee employee, int id)
        {
            if (employee.Id != id)
            {
                return BadRequest("El id por ruta no conincide con el id del empleado");
            }

            context.Update(employee);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return Ok();
        }
     

    }
}
