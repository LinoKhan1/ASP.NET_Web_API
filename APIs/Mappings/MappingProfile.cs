using AutoMapper;
using restful_api.APIs.DTOs;
using restful_api.Core.Entities;

namespace restful_api.APIs.Mappings
{
    /// <summary>
    /// AutoMapper profile for configuring object-to-object mappings.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// Configures the mappings between <see cref="Product"/> and <see cref="ProductDTO"/>.
        /// </summary>
        public MappingProfile()
        {
            // Create a mapping between Product and ProductDTO
            CreateMap<Product, ProductDTO>()
                .ReverseMap(); // Create the reverse mapping as well
        }
    }
}
