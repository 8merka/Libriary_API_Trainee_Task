﻿using AutoMapper;
using Libriary_BAL.DTOs;
using Libriary_BAL.Services.IService;
using Libriary_BAL.Utilities.Constants;
using Libriary_BAL.Utilities.Exceptions;
using Libriary_DAL.Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Services
{
    public class AuthService(
        UserManager<User> userManager,
        ITokenService tokenService,
        IMapper mapper,
        ILogger<AuthService> logger
        ) : IAuthService
    {
        private readonly UserManager<User> _userManager = userManager;

        private readonly ITokenService _tokenService = tokenService;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<AuthService> _logger = logger;

        public async Task<TokenDTO?> AuthAsync(LoginDTO loginCredentials, CancellationToken cancellationToken)
        {
            User user = await ValidateAuthenticationAsync(loginCredentials.Email, loginCredentials.Password);

            var tokenDto = await _tokenService.CreateTokenAsync(user, Exp: true);

            return tokenDto;
        }

        public async Task<bool> RegAsync(RegisterDTO registerCredentials, CancellationToken cancellationToken)
        {
            await ValidateRegisterAsync(registerCredentials.Email);

            var user = _mapper.Map<User>(registerCredentials);

            await CreateUserAsync(user, registerCredentials.Password);

            _logger.LogInformation("Role {role} were added to user {name}", Roles.User, user.UserName);

            await _userManager.AddToRoleAsync(user, Roles.User);

            return true;
        }

        private async Task<User> ValidateAuthenticationAsync(string email, string password)
        {
            _logger.LogInformation("Searching for user with email {email} ", email);
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                _logger.LogDebug("No User");
                throw new BadRequestException(Messages.noUser);
            }

            _logger.LogInformation("User: {id} {email} {name}", user.Id, user.Email, user.UserName);
            var IsPasswordValid = await _userManager.CheckPasswordAsync(user, password);

            if (!IsPasswordValid)
            {
                _logger.LogDebug("Invalid Password");
                throw new BadRequestException(Messages.invalidPassword);
            }

            return user;
        }
        private async Task ValidateRegisterAsync(string email)
        {
            _logger.LogDebug("Searching for user with email {email} ", email);
            var emailTaken = await _userManager.FindByEmailAsync(email);

            if (emailTaken is not null)
            {
                _logger.LogDebug("User found: {id} {name} {email}", emailTaken.Id, emailTaken.UserName, emailTaken.Email);
                throw new BadRequestException(Messages.emailWasTaken);
            }
        }

        private async Task CreateUserAsync(User user, string password)
        {
            _logger.LogInformation("Creating new user {name} {email}", user.UserName, user.Email);
            var createUser = await _userManager.CreateAsync(user, password);

            if (!createUser.Succeeded)
            {
                _logger.LogError("Error while creating new user {errors}", createUser.Errors);

                throw new BadRequestException(Messages.registerFailed);
            }
        }
    }
}
