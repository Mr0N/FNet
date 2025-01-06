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
            return Enumerable.Range(0, 20_000)
                             .Select((a,index) => new TestDto(index.ToString()));
        }
    }
}
