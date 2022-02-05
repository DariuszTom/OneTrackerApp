using AutoMapper;
using DbDataLibrary.Models;
using DbDataLibrary.Models.Entities;
using System;

namespace DbDataLibrary.Mapper
{
    public class AutoMaperConfig : Profile, IDisposable
    {
        public AutoMaperConfig()
        {
            MyMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DevTeam, TeamForViewNew>().ReverseMap();
                cfg.CreateMap<Employee, DeveloperForView>().ReverseMap();
                cfg.CreateMap<Project, ProjectForView>().ReverseMap();
            });
        }

        private MapperConfiguration _MyMapperConfig;
        public MapperConfiguration MyMapperConfig { get => _MyMapperConfig; set => _MyMapperConfig = value; }

        public void Dispose()
        {
            _MyMapperConfig = null;
            GC.SuppressFinalize(this);
        }
    }
}