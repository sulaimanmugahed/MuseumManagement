﻿using Microsoft.AspNetCore.Http;
using MuseumManagement.Application.Interfaces;
using System.Security.Claims;

namespace MuseumManagement.WebApi.Infrastracture.Services
{
    public class AuthenticatedUserService(IHttpContextAccessor httpContextAccessor) : IAuthenticatedUserService
    {
		public string UserId { get; } = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
		public string UserName { get; } = httpContextAccessor.HttpContext?.User?.Identity.Name;
	}
}
