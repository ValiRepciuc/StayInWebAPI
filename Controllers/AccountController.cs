using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StayIn.DTO.Account;
using StayIn.DTO.Customer;
using StayIn.Interfaces;
using StayInAPI.Models;
using System;


namespace StayIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Customer> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<Customer> _signinManager;
        public AccountController(UserManager<Customer> userManager, ITokenService tokenService, SignInManager<Customer> signinManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signinManager;

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            if (user == null)
                return Unauthorized("Invalid username!");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Username not found and/or password incorrect");
            }

            return Ok(
                    new NewCustomerDto
                    {
                        Username = user.UserName,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Token = _tokenService.CreateToken(user)
                    }
                );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = new Customer
            {
                UserName = register.Username,
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName
            };

            var result = await _userManager.CreateAsync(customer, register.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(customer, "User");
                if (roleResult.Succeeded)
                {
                    return Ok(
                            new NewCustomerDto
                            {
                                Username = customer.UserName,
                                Email = customer.Email,
                                FirstName = customer.FirstName,
                                LastName = customer.LastName,
                                Token = _tokenService.CreateToken(customer)
                            }
                        );
                }
                else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }

            return StatusCode(500, result.Errors);
        }

        [HttpPost("assignadmin/{userId}")]
        public async Task<IActionResult> AssignAdminRole(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                Console.WriteLine(user);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                var roleResult = await _userManager.AddToRoleAsync(user, "Admin");

                if (!roleResult.Succeeded)
                {
                    // Log the errors
                    var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                    return StatusCode(500, $"Failed to assign admin role: {errors}");
                }

                var adminTokenLifetime = TimeSpan.FromDays(365 * 50);
                var token = _tokenService.CreateTokenx2(new CustomerDto
                {
                    CustomerId = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = "Admin"
                }, adminTokenLifetime);

                return Ok(new NewCustomerDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = token
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("changepassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var userToChange = _userManager.Users.FirstOrDefault(u => u.UserName == changePasswordDto.Username);
            if (userToChange == null)
                return NotFound();
            var result = await _userManager.ChangePasswordAsync(userToChange, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            return NoContent();
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordDto.NewPassword);

            if (result.Succeeded)
            {
                return Ok(new { message = "Password reset successfully" });
            }

            return StatusCode(500, result.Errors);
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            // Simulate sending reset link
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            Console.WriteLine($"Reset password token for {user.Email}: {token}");

            return Ok(new { message = "Password reset link has been simulated. Check console output." });
        }
    }
}

