using EmployeeWebAPI.Interface;
using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        private readonly IEmployee _db;

        public EmployeeController(IEmployee db)
        {
            _db = db;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                var result = _db.GetEmployees().ToList();

                return StatusCode(200,result);
            }
            catch (Exception ex)

            {
                return BadRequest(ex);
            }
        }

       

        // POST
        [HttpPost]
        public async Task<ActionResult> PostEmployee(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.PostEmployee(employee);

                    return StatusCode(200, "Added Successfully");
                }
                else
                {
                    return BadRequest();
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        // PUT
        [HttpPut]
        public async Task<IActionResult> PutEmployee(Employee employee)
        {
            
            try
            {
                    var result = _db.PutEmployee(employee);

                    return StatusCode(200, "Updated Successfully");
              
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {

            try
            {
                if (_db.Id(id))
                {
                    var result = _db.DeleteEmployee(id);


                    return StatusCode(200, "Delete SuccessFully");
                }

                return NotFound("Id does not exists");

            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }

    }
}
