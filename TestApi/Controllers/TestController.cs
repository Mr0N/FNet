using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{
    public record TestDto(string text);
    [ApiController]
    [Route("[controller]")]
   
    public class TestController : ControllerBase
    {
     
        [HttpGet]
        public IEnumerable<TestDto> TestRequest()
        {
            return new TestDto[] {
                new TestDto("Hello, World!")
            };
        }
    }
}
