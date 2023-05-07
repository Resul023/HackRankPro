﻿using Application.Common.Interfaces;
using Domain.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Infrastructure.Identity;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Infrastructure.Persistence;
public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) { }

    public DbSet<Credit> Credits { get ; set; }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    //    base.OnModelCreating(builder);
    //}
}
