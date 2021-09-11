using AutoMapper;
using WebApiRest.Entities;
using WebApiRest.Models;

namespace WebApiRest.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductReview, ProductReviewViewModel>();
            CreateMap<ProductReview, ProductReviewDetailsViewModel>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductDetailsViewModel>();
        }
    }
}