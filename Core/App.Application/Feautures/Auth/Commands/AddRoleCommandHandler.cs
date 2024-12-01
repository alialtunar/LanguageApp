using App.Application.Interfaces;
using App.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Feautures.Auth.Commands
{
    public class AddRoleCommand : IRequest<ServiceResult>
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, ServiceResult>
    {
        private readonly IAuthRepository _authRepository;

        public AddRoleCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<ServiceResult> Handle(AddRoleCommand command, CancellationToken cancellationToken)
        {
            await _authRepository.AddRoleAsync(command, cancellationToken);
            return ServiceResult.Success(System.Net.HttpStatusCode.OK);
        }
    }
}
