using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiskStartupSchool.DTO;
using MiskStartupSchool.Entities;
using MiskStartupSchool.Services;

namespace MiskStartupSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyAppTemplateController : ControllerBase
    {
        private readonly IAppTemplate _temp;

        public MyAppTemplateController(IAppTemplate temp)
        {
            _temp = temp;
        }

        [HttpGet("get-apptemp")]
        public async Task<IActionResult> GetAppTemp(string Id)
        {
            var data = await _temp.GetTemplate(Id);
            return Ok(data);
        }

        [HttpPut("update-apptemp")]
        public async Task<IActionResult> UpdateWorkflow(AppTemplateDto program, string Id)
        {
            var data = await _temp.UpdateTemplate(program, Id);
            return data ? Ok(StatusCode(200)) : BadRequest(StatusCode(404));
        }
    }
}
