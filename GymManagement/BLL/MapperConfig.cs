using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;

namespace BLL
{
    public class MapperConfig
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, RegDTO>().ReverseMap();
            cfg.CreateMap<User, UserDTO>().ReverseMap();
            cfg.CreateMap<Trainer, TrainerDTO>().ReverseMap();
            cfg.CreateMap<Package, PackageDTO>().ReverseMap();
        });

        public static Mapper GetMapper()
        {
            return new Mapper(config);
        }
    }
}