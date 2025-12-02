using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Extentions
{
    public static class DbExtention
    {
        public static IHost MigrateDatabase<TContext>(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var config = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();

                try
                {
                    logger.LogInformation("Discount DB migration statred");
                    ApplyMigrations(config);
                    logger.LogInformation("Discount DB migration completed");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex,"Cann't create database migration ");
                }
            }
            return host;
        }
        private static void ApplyMigrations(IConfiguration config)
        {
            var retry = 5;

            while (retry > 0)
            {
                try
                {
                    using var connection = new NpgsqlConnection(config.GetValue<string>("DatabaseSetting:ConnectionString"));
                    connection.Open();
                    using var cmd = new NpgsqlCommand
                    {
                        Connection = connection,
                    };
                    cmd.CommandText = "DROP TABLE IF EXISTS Coupon";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"CREATE TABLE Coupon (ID SERIAL PRIMARY KEY,
                                                      ProductName VARCHAR(500) NOTNULL ,
                                                      Description TEXT,
                                                      DiscountAmount INT";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO Coupon(ProductName,Description,DiscountAmout)VALUES('KeyBoard','Intel KeyBoard',20)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Coupon(ProductName,Description,DiscountAmout)VALUES('PowerFit','Power fit discount',10)";
                    cmd.ExecuteNonQuery();
                    break;
                }
                catch (Exception)
                {

                    retry--;
                    if(retry == 0)
                    {
                        throw;
                    }
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
