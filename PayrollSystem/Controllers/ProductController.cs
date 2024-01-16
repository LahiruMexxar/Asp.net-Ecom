using BLL.Services.IServices;
using DAL.Data;
using DAL.DTO;
using DAL.DTO.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PayrollSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //Create an product
        [HttpPost("Createroduct")]

        public async Task<ResponseDTO<CreateProductDTO>> createAProduct(CreateProductDTO createProductDTO)
        {
            var product = await _productService.CreateProduct(createProductDTO);
            if(product !=null)
            {
                var response = new ResponseDTO<CreateProductDTO>
                {
                    code = 200,
                    isSuccess = true,
                    message = product.Name,
                    data = product
                };
                return response;
            }
            else return new ResponseDTO<CreateProductDTO> { isSuccess = false };
        }
    }
}
