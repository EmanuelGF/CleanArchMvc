using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings
{
    /// <summary>
    /// This is responsible for mapping the DTO to entities and the other way around.
    /// </summary>
    public class DomainToDTOMappingProfile : Profile
    {
        /// <summary>
        /// through the resourses of Profile its possible to map
        /// the domain entities to the DTO classes.
        /// </summary>
        public DomainToDTOMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
