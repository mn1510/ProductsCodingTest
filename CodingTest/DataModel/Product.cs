using AutoMapper;

namespace CodingTest.DataModel
{
    public class Product
    {
        public int Id { get; set; }
        public ProductName? Name { get; set; }
        public ProductColour? Colour { get; set; }

    }

    public class ProductDTO
    {
        public string? Name { get; set; }
        public string? Colour { get; set; }
    }

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToString()))
                .ForMember(dest => dest.Colour, opt => opt.MapFrom(src => src.Colour.ToString()));
        }
    }

}