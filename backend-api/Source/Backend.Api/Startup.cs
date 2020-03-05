using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Backend.Application.Services;
using Backend.Domain.Core.Bus;
using Backend.Domain.Core.Commands;
using Backend.Domain.Core.Notifications;
using Backend.Domain.Core.Queries;
using Backend.Domain.Models.ProductModel;
using Backend.Domain.Models.ProductModel.Commands;
using Backend.Infra.Repositories;
using Backend.Domain.Models.ProductModel.Queries;
using System.Collections.Generic;
using Backend.Domain.Models.CartModel.Commands;
using Backend.Domain.Models.CartModel;
using Amazon;
using Amazon.Runtime;
using Backend.Domain.Models.ProductModel.Repositories;
using Backend.Domain.Models.CartModel.Repositories;
using Backend.Domain.Models.CartModel.Queries;

namespace Backend.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.AddSingleton<AmazonDynamoDBClient>(serviceConfiguration =>
            {
                var credentials = Program.Credentials;
                return new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
            });

            services.AddScoped<IBus, Bus>();
            services.AddScoped<INotificationHandler, NotificationHandler>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartService, CartService>();

            // Product Commands
            services.AddTransient<ICommandHandler<ProductCreateCommand, Product>, ProductCreateCommandHandler>();

            // Product Queries
            services.AddTransient<IQueryHandler<ProductGetAllQuery, List<Product>>, ProductGetAllQueryHandler>();
            services.AddTransient<IQueryHandler<ProductGetByIdQuery, Product>, ProductGetByIdQueryHandler>();
            services.AddTransient<IQueryHandler<ProductGetBySkuQuery, Product>, ProductGetBySkuQueryHandler>();

            // Cart Commands
            services.AddTransient<ICommandHandler<CartCheckoutCommand, Cart>, CartCheckoutCommandHandler>();
            services.AddTransient<ICommandHandler<CartCreateCommand, Cart>, CartCreateCommandHandler>();
            services.AddTransient<ICommandHandler<CartUpdateCommand, Cart>, CartUpdateCommandHandler>();
            services.AddTransient<ICommandHandler<CartDeleteCommand, Cart>, CartDeleteCommandHandler>();
            services.AddTransient<ICommandHandler<CartDeleteItemCommand, Cart>, CartDeleteItemCommandHandler>();

            // Cart Queries
            services.AddTransient<IQueryHandler<CartGetAllQuery, List<Cart>>, CartGetAllQueryHandler>();
            services.AddTransient<IQueryHandler<CartGetByIdQuery, Cart>, CartGetByIdQueryHandler>();
            services.AddTransient<IQueryHandler<CartGetByCustomerIdQuery, Cart>, CartGetByCustomerIdQueryHandler>();

            // Invoice Commands
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
