using AutoMapper;
using DbDataLibrary.Models.DisplayModel;
using DbDataLibrary.Models.Entities;
using System;

namespace DbDataLibrary.Mapper
{
    public class DisplayMaperConfig : Profile, IDisposable
    {
        public DisplayMaperConfig()
        {
            MyMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Department, DepartmentDisplay>().ReverseMap();
                cfg.CreateMap<DevTeam, TeamsDisplay>().ReverseMap();
                cfg.CreateMap<Employee, DevelopertDisplay>().ReverseMap();
                cfg.CreateMap<Project, ProjectDisplay>().ReverseMap();
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