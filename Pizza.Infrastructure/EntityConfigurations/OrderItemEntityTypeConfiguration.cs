using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pizza.Domain.AggregateModel.OrderAggregate;

namespace Pizza.Infrastructure.EntityConfigurations
{
    public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public OrderItemEntityTypeConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("orderItems");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .UseHiLo("oitemseq");

            builder.Property(o => o.PizzaName).HasMaxLength(300).IsRequired();
            builder.Property(o => o.Price).IsRequired();

        }
    }
}
