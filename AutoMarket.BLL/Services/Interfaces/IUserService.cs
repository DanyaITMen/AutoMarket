using AutoMarket.BLL.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoMarket.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(string id); // Зверни увагу - id тут string!
    }
}