using AutoMapper;
using AutoMarket.BLL.DTOs.User;
using AutoMarket.BLL.Services.Interfaces;
using AutoMarket.DAL.Repositories; 
using System.Collections.Generic;
using AutoMarket.DAL.Repositories.Interfaces;
using System.Threading.Tasks;

namespace AutoMarket.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }
    }
}