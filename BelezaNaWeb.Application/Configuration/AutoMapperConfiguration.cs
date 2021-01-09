using AutoMapper;
using BelezaNaWeb.Application.DTOs;
using BelezaNaWeb.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Application.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection ConfigAutoMapper(this IServiceCollection services, params Type[] profileAssemblyMarkerTypes)
        {
            services.AddAutoMapper(profileAssemblyMarkerTypes);

            return services;
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProdutoDTO, ProdutoEntity>()
                .ForMember(dest => dest.ProdutoInventarioEntity, opt => opt.MapFrom(src => src.Inventory))
                .ReverseMap();

            CreateMap<ProdutoInventarioDTO, ProdutoInventarioEntity>()
                .ForMember(dest => dest.ProdutoArmazemEntities, opt => opt.MapFrom(src => src.Warehouses))
                .ReverseMap();

            CreateMap<ProdutoArmazemDTO, ProdutoArmazemEntity>().ReverseMap();

        }
    }
}
