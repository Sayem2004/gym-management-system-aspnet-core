using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class UserService
    {
        UserRepo repo;
        Mapper mapper;

        public UserService(UserRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public bool Create(RegDTO obj)
        {
            var data = mapper.Map<User>(obj);
            return repo.Create(data);
        }

        public List<RegDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<RegDTO>>(data);
        }

        public RegDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<RegDTO>(data);
        }






        public List<UserDTO> GetAll()
        {
            var data = repo.Get();

            return mapper.Map<List<UserDTO>>(data);
        }

        public UserDTO GetUser(int id)
        {
            var data = repo.Get(id);

            return mapper.Map<UserDTO>(data);
        }

        public bool Update(UserDTO obj)
        {
            var data = mapper.Map<User>(obj);

            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }





        public bool Authenticate(LoginDTO obj)
        {
            var user = repo.Authenticate(obj.Username, obj.Password);

            if (user != null)
            {
                return true;
            }

            return false;
        }

        public User Get(string uname)
        {
            return repo.Get(uname);
        }
    }
}