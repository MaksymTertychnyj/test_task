using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using test_task.Data.Entities;
using test_task.Services;

namespace test_task.Controllers
{
    [Route("request/")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost("addIncident")]
        public async Task<IActionResult> AddIncident([FromBody] RequestParameter parameters)
        {
            if (ModelState.IsValid)
            {
                var response = await _requestService.AddNewIncident(parameters);

                if (!response.Equals(string.Empty))
                {
                    return Ok(response);
                }
                return NotFound();
            }

            return BadRequest();
        }

        [HttpPost("createAccount")]
        public async Task<IActionResult> CreateAccount([FromBody] RequestParameter parameters)
        {
            if (ModelState.IsValid)
            {
                var response = await _requestService.CreateAccount(parameters);

                return Ok(response);
            }

            return BadRequest();
        }

        [HttpPost("createContact")]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {
                var response = await _requestService.CreateContact(contact);

                return Ok(response);
            }

            return BadRequest();
        }
    }
}
