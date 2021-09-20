﻿using Banking.Operation.Contact.Domain.Contact.Repositories;
using Banking.Operation.Contact.Infra.Data;
using Banking.Operation.Contact.Infra.Data.Contact.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Net.Core.Template.CrossCutting.Ioc.Modules
{

    public static class DataModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

            services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, serverVersion));

            services.AddScoped<IContactRepository, ContactRepository>();
        }
    }
}
