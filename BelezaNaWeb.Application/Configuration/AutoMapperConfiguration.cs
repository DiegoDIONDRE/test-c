using AutoMapper;
using BelezaNaWeb.Application.DTOs;
using BelezaNaWeb.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Application.Configuration
{
    public class AutoMapperConfiguration: Profile
    {
        public static IMapper ConfigAutoMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProdutoEntity, ProdutoDTO>()
                    .ForMember(dest => dest.Inventory, opt => opt.MapFrom(src => src.ProdutoInventarioEntity))
                    .ReverseMap();

                cfg.CreateMap<ProdutoInventarioEntity, ProdutoInventarioDTO>()
                    .ForMember(dest => dest.Warehouses, opt => opt.MapFrom(src => src.ProdutoArmazemEntities))
                    .ReverseMap();

                cfg.CreateMap<ProdutoArmazemEntity, ProdutoArmazemDTO>()
                    .ReverseMap();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
