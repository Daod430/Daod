using DaodApi.Data;
using DaodApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FormAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FormController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitForm([FromBody] FormDataModel formData)
        {
            if (ModelState.IsValid)
            {
                // Add form data to the database
                _context.FormData.Add(formData);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Form submitted and saved successfully!" });
            }
            return BadRequest("Invalid data.");
        }
    }
}
