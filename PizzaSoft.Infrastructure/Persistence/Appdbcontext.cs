using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaSoft.Application.Common.Interfaces.Persistence;

namespace PizzaSoft.Infrastructure.Persistence
{

    public partial class Appdbcontext : DbContext, IAppdbcontext
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public Appdbcontext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
