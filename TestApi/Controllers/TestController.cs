using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{
    public record TestDto(string text);
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
     
        [HttpGet]
        public IEnumerable<TestDto> Get()
        {
            yield return new TestDto("Hello, World!");
        }
    }
}
