using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pro401.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro401.Test
{
    public class BaseTest
    {
        protected ApplicationDbContext BuieldDataBaseContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var dbContext = new ApplicationDbContext(options);

            return dbContext;
        }

        protected IMapper BuildMapper() 
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Profiles>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}
