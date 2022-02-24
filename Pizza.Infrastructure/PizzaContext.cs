using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using pizza.Domain.AggregateModel.OrderAggregate;
using Pizza.Infrastructure.EntityConfigurations;

namespace Pizza.Infrastructure
{
    public class PizzaContext : DbContext
    {

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderItemEntityTypeConfiguration());
            builder.ApplyConfiguration(new OrderTypeConfiguration());
        }

        public class PizzaContextDesignFactory : IDesignTimeDbContextFactory<PizzaContext>
        {
            public PizzaContext CreateDbContext(string[] args)
            {

                var optionsBuilder = new DbContextOptionsBuilder<PizzaContext>()
                    .UseSqlServer("Server=tcp:127.0.0.1,5433;Initial Catalog=pizzadb;User Id=sa;Password=Pass@word");

                return new PizzaContext(optionsBuilder.Options);
            }
        }


    }
}
