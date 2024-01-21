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

        //to get all products
        public async Task<List<ViewPrductDTO>> getAllProducts()
        {
            var productList = _unitOfWork.Product.GetAll();
            var products = _mapper.Map<List<ViewPrductDTO>>(productList);
            return products;
        }

        //to get product by Id
        public async Task<ViewPrductDTO> getProductByID(int productID)
        {
            //get product by Id
            var product = _unitOfWork.Product.GetById(productID);
            //then map the product with the DTO
            var mappedProduct = _mapper.Map<ViewPrductDTO>(product);
            //return the product
            return mappedProduct;
        }

        public async Task<ProductDTO> CreateProduct(ProductDTO createProductDTO)
        {
            if (createProductDTO is null ) 
            {
                return createProductDTO;
            }

            Product product = _mapper.Map<Product>(createProductDTO);
            _unitOfWork.Product.Add( product );
            await _unitOfWork.SaveAsync();

            createProductDTO = _mapper.Map<ProductDTO>(product);
            return createProductDTO;
        }

        // to update the product
        public async Task<ViewPrductDTO> updateProduct (ProductDTO updatedProductDTO, int productID)
        {
            ViewPrductDTO viewPrductDTO = new ViewPrductDTO();
            //get product by ID
            var product = _unitOfWork.Product.GetById(productID);
            // check if the searched product ID is present
            if (product != null )
            {
                _mapper.Map(viewPrductDTO, product);
                await _unitOfWork.SaveAsync();
                viewPrductDTO = _mapper.Map<ViewPrductDTO>(product);
                return viewPrductDTO;
            }
            //return the updated product
            return viewPrductDTO;
        }

        public async Task<bool> deleteProduct(int productID)
        {
            //get product by ID
            var product = _unitOfWork.Product.GetById(productID);
            //then check if the product Id is present (need to implement soft delete fuctionality)
            if(product != null )
            {
                _unitOfWork.Product.Remove( product );
                await _unitOfWork.SaveAsync();
                return true;
            }
            return false;
        }


    }
}
