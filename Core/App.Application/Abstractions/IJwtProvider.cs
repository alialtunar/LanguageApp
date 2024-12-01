using App.Application.Feautures.Auth.Dto;
using App.Domain.Entities;

namespace App.Application.Abstractions
{
    public interface IJwtProvider
    {
        Task<AuthenticationResultDto> CreateTokenAsync(ApplicationUser user);
    }
}
