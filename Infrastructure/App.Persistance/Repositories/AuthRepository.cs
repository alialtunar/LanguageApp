using App.Application.Abstractions;
using App.Application.Feautures.Auth.Commands;
using App.Application.Feautures.Auth.Dto;
using App.Application.Interfaces;
using App.Domain.Entities;
using App.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace App.Persistance.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtProvider _jwtProvider;

        public AuthRepository(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> RegisterAsync(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.User.ToString());
                    return $"User Registered {user.UserName}";
                }
            }
            return $"Email {user.Email} is already registered.";
        }

        public async Task<string> AddRoleAsync(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return $"No Accounts Registered with {request.Email}.";

            if (await _userManager.CheckPasswordAsync(user, request.Password))
            {
                if (Enum.TryParse<Roles>(request.Role, true, out var role))
                {
                    await _userManager.AddToRoleAsync(user, role.ToString());
                    return $"Added {request.Role} to user {request.Email}.";
                }
                return $"Role {request.Role} not found.";
            }
            return $"Incorrect Credentials for user {user.Email}.";
        }

        public async Task<AuthenticationResultDto> LoginAsync(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);

            if (user == null) throw new Exception("Kullanıcı bulunamadı!");

            var result = await _userManager.CheckPasswordAsync(user, command.Password);
            if (result)
            {
                AuthenticationResultDto response = await _jwtProvider.CreateTokenAsync(user);
                return response;
            }

            throw new Exception("Şifreyi yanlış girdiniz!");
        }
    }

}
