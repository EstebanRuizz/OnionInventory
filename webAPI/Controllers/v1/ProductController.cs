using Application.Features.Products.Commands.CreateProduct;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseAPIController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }
    }
}
