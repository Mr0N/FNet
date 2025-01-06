using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{
    public record TestDto(string text);
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {

        [HttpGet("test")]
        public IEnumerable<TestDto> Test()
        {
            return new TestDto[] {
                new TestDto("Hello, World!")
            };
        }
    }
}
