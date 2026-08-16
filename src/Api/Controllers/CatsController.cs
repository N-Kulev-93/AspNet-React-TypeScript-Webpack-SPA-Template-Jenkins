using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Api.Controllers
{
    public class CatDto
    {
        public required int Id { get; set; }
        public static IEnumerable<CatDto> FatCatFamily => [new() { Id = 1 }, new() { Id = 2 }, new() { Id = 3 }];
    }

    /// <summary>
    /// Example controller for template clients.
    /// </summary>
    [Route("api/[controller]")] 
    [ApiController]
    public class CatsController : ControllerBase
    {
        [HttpGet("{id:int}")]
        [EndpointDescription("Get the Fat Cat's familiy member by id.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CatDto> Get([Description("Unique cat identifier.")] int id)
        {
            var familyCat = CatDto.FatCatFamily.FirstOrDefault(cat => cat.Id == id);

            return familyCat != null ? Ok(familyCat) : NotFound();
        }
    }
}
