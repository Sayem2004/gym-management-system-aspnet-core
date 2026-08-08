using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class TrainerService
    {
        TrainerRepo repo;
        Mapper mapper;

        public TrainerService(TrainerRepo repo)
        {
            this.repo = repo;

            mapper = MapperConfig.GetMapper();
        }

        public bool Create(TrainerDTO obj)
        {
            var data = mapper.Map<Trainer>(obj);

            return repo.Create(data);
        }

        public List<TrainerDTO> Get()
        {
            var data = repo.Get();

            return mapper.Map<List<TrainerDTO>>(data);
        }

        public TrainerDTO Get(int id)
        {
            var data = repo.Get(id);

            return mapper.Map<TrainerDTO>(data);
        }

        public bool Update(TrainerDTO obj)
        {
            var data = mapper.Map<Trainer>(obj);

            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

     
    }
}