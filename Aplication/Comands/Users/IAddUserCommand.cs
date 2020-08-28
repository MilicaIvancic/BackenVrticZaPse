using Aplication.Interfaces;
using Aplication.DTO.UserDTO;

namespace Aplication.Comands.Users
{
    public interface IAddUserCommand:ICommand<UserDto>
    {
    }
}
