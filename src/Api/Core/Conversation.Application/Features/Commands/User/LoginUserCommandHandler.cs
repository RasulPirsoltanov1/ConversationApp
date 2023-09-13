using AutoMapper;
using Conversation.Api.Application.Interfaces.Repositories;
using Conversation.Common.Infrastructure;
using Conversation.Common.Infrastructure.Exceptions;
using Conversation.Common.ViewModels.Queries;
using Conversation.Common.ViewModels.RequestModels;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Api.Application.Features.Commands.User
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private IConfiguration _configuration;
        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);
            if (dbUser == null)
            {
                throw new DataBaseValidationException("User not Found!");
            }
            var hashRequestPass = PasswordEncryptor.Encrypt(request.Password);
            if (hashRequestPass != dbUser.Password)
            {
                throw new DataBaseValidationException("Wrong Username or Password!");
            }
            if (!dbUser.EmailConfirmed)
            {
                throw new DataBaseValidationException("Confirm your Email!");
            }
            var result = _mapper.Map<LoginUserViewModel>(dbUser);
            Claim[] claims = new Claim[] {
            new Claim(ClaimTypes.NameIdentifier,dbUser.Id.ToString()),
            new Claim(ClaimTypes.Email,dbUser.EmailAddress),
            new Claim(ClaimTypes.Name,dbUser.Username),
            new Claim(ClaimTypes.GivenName,dbUser.FirstName),
            new Claim(ClaimTypes.Surname,dbUser.LastName)
            };

            result.Token = GenerateToken(claims);
            return result;
        }

        private string GenerateToken(Claim[] claim)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthConfig:Secret"]));
            var sigInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.Now.AddDays(10);
            var jwtSecurityToken = new JwtSecurityToken(issuer: _configuration["AuthConfig:Issuer"]
                , audience: _configuration["AuthConfig:Audience"]
                , claims: claim
                , expires: expireDate
                , signingCredentials: sigInCredentials);
            var jwtTokenHandler = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return jwtTokenHandler;
        }
    }
}
