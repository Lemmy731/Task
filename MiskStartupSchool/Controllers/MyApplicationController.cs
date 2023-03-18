using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiskStartupSchool.DTO;
using MiskStartupSchool.Services;

namespace MiskStartupSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyApplicationController : ControllerBase
    {
        private readonly IApplicationRepo _appRepo;

        public MyApplicationController(IApplicationRepo apprepo)
        {
            _appRepo = apprepo;
        }
        [HttpPost("application")]
        public async Task<IActionResult> PostApplication([FromBody] ApplicationDto application)
        {
            return Ok(await _appRepo.Add(application));
        }

        [HttpGet("program")]
        public async Task<IActionResult> GetProgram(string Id)
        {
           var data = await _appRepo.GetProgram(Id);
            return Ok(data);
        }


        [HttpGet("preview")]
        public async Task<IActionResult> AllProgram()
        {
            var data = await _appRepo.GetAllProgram();
            return Ok(data);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProgramDto program, string Id)
        {
            var data = await _appRepo.UpdateProgram(program, Id);
            return data? Ok(StatusCode(200)) : BadRequest(StatusCode(404));
        }
    }
}
