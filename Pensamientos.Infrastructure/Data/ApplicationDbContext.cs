using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Pensamientos.Domain;
using Pensamientos.Domain.Models;

namespace Pensamientos.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
    }
}
