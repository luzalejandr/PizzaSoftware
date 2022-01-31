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

        public async Task<List<Pizza>> GetPizzas()
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            string query = @"
                     SELECT ""Id""
                       ,""Name""
                       ,""Detail""
                       ,""Price""
                       ,""Toppings""    
                       ,""Status""
                     FROM public.""Pizza""
                     WHERE ""Status"" = true";
            var result = await connection.QueryAsync<Pizza>(query);
            return result.ToList();
        }


        public async Task<Pizza> CreatePizza(Pizza pizza)
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            string query = @"
                     INSERT INTO public.""Pizza""
                       (""Id""
                       ,""Name""
                       ,""Detail""
                       ,""Price""
                       ,""Toppings""
                       ,""Status"")
                     VALUES
                       (@Id
                       ,@Name
                       ,@Detail          
                       ,@Price
                       ,@Toppings
                       ,@Status)";
            await connection.QueryAsync<Pizza>(query, pizza);
            return pizza;
        }

        public async Task<string> DeletePizza(Guid id)
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            string query = @"
                     DELETE from public.""Pizza""
                     where  ""Id"" = @Id ";
            var result = await connection.QueryAsync<Pizza>(query, new
            {
                @Id = id
            });
            return "ok";
        }

        public async Task<Pizza> GetPizzaById(Guid id)
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            string query = @"
                     SELECT * from public.""Pizza""
                     where  ""Id"" = @Id ";
            var result = await connection.QueryAsync<Pizza>(query, new
            {
                @Id = id
            });
            return result.FirstOrDefault();
        }

        public async Task<Pizza> AddToppingtoPizza(Guid idPizza, Guid[] idToppings)
        {
            using IDbConnection connection = new NpgsqlConnection(_connectionString);
            string query = @"
                     UPDATE  public.""Pizza""
                     SET  ""Toppings"" = @idToppings
                     where ""Id""= @idPizza";
            var result = await connection.QueryAsync<Pizza>(query, new
            {
                @idPizza = idPizza,
                @idToppings = idToppings
            });
            return result.FirstOrDefault();
        }





    }
}
