using App.Application.Feautures.Auth.Commands;
using App.Application.Feautures.Auth.Dto;

namespace App.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> RegisterAsync(RegisterCommand request, CancellationToken cancellationToken);
        Task<string> AddRoleAsync(AddRoleCommand request, CancellationToken cancellationToken);
        Task<AuthenticationResultDto> LoginAsync(LoginCommand command, CancellationToken cancellationToken);
    }
}
