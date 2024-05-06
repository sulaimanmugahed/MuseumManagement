using Microsoft.AspNetCore.Identity;
using System;

namespace MuseumManagement.Infrastructure.Identity.Models
{
    public class ApplicationRole(string name)
        : IdentityRole<Guid>(name)
    {
    }
}