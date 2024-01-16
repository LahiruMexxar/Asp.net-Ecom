using AutoMapper;
using BLL.Services.IServices;
using DAL.DTO.Product;
using DAL.Models;
using DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : IProductService

    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateProductDTO> CreateProduct(CreateProductDTO createProductDTO)
        {
            if (createProductDTO is null ) 
            {
                return createProductDTO;
            }

            Product product = _mapper.Map<Product>(createProductDTO);
            _unitOfWork.Product.Add( product );
            await _unitOfWork.SaveAsync();

            createProductDTO = _mapper.Map<CreateProductDTO>(product);
            return createProductDTO;
        }
    }
}
