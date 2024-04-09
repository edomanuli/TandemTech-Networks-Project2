using DTOs;
using Microsoft.VisualBasic;
using Service.Contracts;
using Repository.Contracts;
using AutoMapper;
using Entities;
using Entities.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User? _user;

        public UserService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> AuthenticateUser(UserLoginDto userLogin)
        {
            // Find the user by username
            var user = await _userManager.FindByNameAsync(userLogin.Username);
            if (user == null)
            {
                _logger.LogInfo($"Authentication failed for user {userLogin.Username}: User not found.");
                return false;
            }

            // Check password
            var result = await _userManager.CheckPasswordAsync(user, userLogin.Password);
            if (!result)
            {
                _logger.LogInfo($"Authentication failed for user {userLogin.Username}: Incorrect password.");
            }

            return result;
        }

        public async Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistration)
        {
            var user = _mapper.Map<User>(userRegistration);
            var result = await _userManager.CreateAsync(user, userRegistration.Password);

            if (!result.Succeeded)
            {
                _logger.LogError($"Registration failed for user {userRegistration.Username}. Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            return result;
        }

        public async Task<string> CreateToken()
        {
            if (_user == null)
            {
                throw new InvalidOperationException("No authenticated user available for token generation.");
            }

            // Get credentials
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Prepare claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Generate token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),  // Set the token expiration
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
