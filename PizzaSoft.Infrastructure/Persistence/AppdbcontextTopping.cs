using Dapper;
using Npgsql;
using PizzaSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSoft.Infrastructure.Persistence
{
    public partial class Appdbcontext
    {

        public async Task<Topping> CreateTopping(Topping topping)
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            string query = @"
                     INSERT INTO public.""Topping""
                       (""Id""
                       ,""Name""
                       ,""Status"")
                     VALUES
                       (@Id
                       ,@Name
                       ,@Status)";
            await connection.QueryAsync<Pizza>(query, topping);
            return topping;
        }


        public async Task<List<Topping>> GetToppings()
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            string query = @"
                     SELECT ""Id""
                       ,""Name""  
                       ,""Status""
                     FROM public.""Topping""
                     WHERE ""Status"" = true";
            var result = await connection.QueryAsync<Topping>(query);
            return result.ToList();
        }


        public async Task<string> DeleteToppings(Guid id)
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            string query = @"
                     DELETE from public.""Topping""
                     where  ""Id"" = @Id ";
            var result = await connection.QueryAsync<Topping>(query, new
            {
                @Id = id
            });
            return "ok";
        }

        public async Task<Topping> GetToppingById(Guid id)
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            string query = @"
                     SELECT * from public.""Topping""
                     where  ""Id"" = @Id ";
            var result = await connection.QueryAsync<Topping>(query, new
            {
                @Id = id
            });
            return result.FirstOrDefault();
        }

    }
}
