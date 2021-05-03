using AutoMapper;
using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Utilities.AutoMapper
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Car, CarDto>();
                CreateMap<CarDto, Car>();

                CreateMap<List<Car>, List<CarDto>>();
                CreateMap<List<CarDto>, List<Car>>();
            }
        }
    }
}
