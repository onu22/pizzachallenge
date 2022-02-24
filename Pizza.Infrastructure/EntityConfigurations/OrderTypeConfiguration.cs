using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pizza.Domain.AggregateModel.OrderAggregate;

namespace Pizza.Infrastructure.EntityConfigurations
{
    public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .UseHiLo("orderseq");

            builder.Property<DateTime>("OrderDate").IsRequired();
            builder.Property(o => o.CustomerId).IsRequired();

            var navigation = builder.Metadata.FindNavigation(nameof(Order.OrderItems));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);


        }
    }
}
