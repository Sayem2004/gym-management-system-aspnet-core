using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class PackageService
    {
        PackageRepo repo;
        Mapper mapper;

        public PackageService(PackageRepo repo)
        {
            this.repo = repo;

            mapper = MapperConfig.GetMapper();
        }

        public bool Create(PackageDTO obj)
        {
            var data = mapper.Map<Package>(obj);

            return repo.Create(data);
        }

        public List<PackageDTO> Get()
        {
            var data = repo.Get();

            return mapper.Map<List<PackageDTO>>(data);
        }

        public PackageDTO Get(int id)
        {
            var data = repo.Get(id);

            return mapper.Map<PackageDTO>(data);
        }

        public bool Update(PackageDTO obj)
        {
            var data = mapper.Map<Package>(obj);

            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
