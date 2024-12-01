using App.Application.Interfaces;
using App.Application.Models;
using App.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Feautures.Auth.Commands
{

    public class RegisterCommand : IRequest<ServiceResult>
    {
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
        [Required]
        public string UserName { get; init; }
        [Required, EmailAddress]
        public string Email { get; init; }
        [Required]
        public string Password { get; init; }
    }
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ServiceResult>
    {
        private readonly IAuthRepository _authRepository;

        public RegisterCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<ServiceResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authRepository.RegisterAsync(request, cancellationToken);
            return ServiceResult.Success(HttpStatusCode.Created);
        }
    }
}
