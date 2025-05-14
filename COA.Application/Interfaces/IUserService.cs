using CustomerOrderService.Application.DTOs;
using System.Threading.Tasks;

namespace CustomerOrderService.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(UserDto userDto);
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
    }
}