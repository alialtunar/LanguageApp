using App.Application.Feautures.Auth.Dto;
using App.Application.Interfaces;
using App.Application.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.Application.Feautures.Auth.Commands
{
    public class LoginCommand : IRequest<ServiceResult<AuthenticationResultDto>>
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ServiceResult<AuthenticationResultDto>>
    {
        private readonly IAuthRepository _authRepository;

        public LoginCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<ServiceResult<AuthenticationResultDto>> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var result = await _authRepository.LoginAsync(command, cancellationToken);
            return ServiceResult<AuthenticationResultDto>.Success(result);
        }
    }
}
