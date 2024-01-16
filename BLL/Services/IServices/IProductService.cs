using DAL.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IProductService
    {
        Task<CreateProductDTO>CreateProduct(CreateProductDTO createProductDTO);
    }
}
