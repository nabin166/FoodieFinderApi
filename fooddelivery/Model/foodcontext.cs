using Microsoft.EntityFrameworkCore;

namespace fooddelivery.Model
{
    public partial class foodcontext:DbContext
    {

        public foodcontext(DbContextOptions options):base(options)
        {

        }
        public virtual DbSet<Categories>? Categories { get; set; }
        public virtual DbSet<CustomerOrders>? CustomerOrders { get; set; }
        public virtual DbSet<Customers>? Customers { get; set; }
        public virtual DbSet<Deliveries>? Deliveries { get; set; }
        public virtual DbSet<Fooditems>? FoodItems { get; set; }
        public virtual DbSet<Orders>? Orders { get; set; }
        public virtual DbSet<Resturants>? Resturants { get; set; }
        public virtual DbSet<Roles>? Roles { get; set; }
        public virtual DbSet<FinalOrders>? FinalOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

              optionsBuilder.UseSqlServer("Server= DESKTOP-SC4NGQA\\SQLEXPRESS;Database=deliveryapp;Integrated Security=True");
            }


        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasOne(e => e.Role)
                .WithMany(p => p.customers)
                .HasForeignKey(d => d.Role_Id); 
            });

          

            modelBuilder.Entity<Deliveries>(entity =>
            {

                entity.HasOne(e => e.FinalOrder)
                .WithMany(p => p.deliveries)
                .HasForeignKey(d => d.FinalOrder_Id);

                entity.HasOne(e => e.Customers)
               .WithMany(p => p.deliveries)
               .HasForeignKey(d => d.Customer_Id);




            });

            modelBuilder.Entity<Fooditems>(entity =>
            {

                entity.HasOne(e => e.Category)
                .WithMany(p => p.fooditems)
                .HasForeignKey(d => d.Category_Id);

                entity.HasOne(e => e.Resturant)
               .WithMany(p => p.fooditems)
               .HasForeignKey(d => d.Resturant_Id);

                // Add configuration for Fooditem_Price
                entity.Property(e => e.Fooditem_Price)
                    .HasColumnType("decimal(18, 2)");




            });
            modelBuilder.Entity<FinalOrders>(entity =>
            {
                // Add configuration for Fooditem_Price
                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(18, 2)");



            });

            modelBuilder.Entity<CustomerOrders>(entity =>
            {

                entity.HasOne(e => e.Order)
                .WithMany(p => p.customerOrders)
                .HasForeignKey(d => d.Order_Id);

                entity.HasOne(e => e.Customer)
               .WithMany(p => p.customerOrders)
               .HasForeignKey(d => d.Customer_Id);




            });

            modelBuilder.Entity<Orders>(entity =>
            {



                entity.HasOne(e => e.FinalOrder)
               .WithMany(p => p.orders)
               .HasForeignKey(d => d.FinalOrder_ID);

                entity.HasOne(e => e.Fooditem)
              .WithMany(p => p.orders)
              .HasForeignKey(d => d.Fooditem_Id);
                // Add configuration for Fooditem_Price
                entity.Property(e => e.Order_Payment)
                    .HasColumnType("decimal(18, 2)");




            });

            modelBuilder.Entity<Resturants>(entity =>
            {



                entity.HasOne(e => e.Customer)
               .WithMany(p => p.resturants)
               .HasForeignKey(d => d.Customer_Id);


            });

            modelBuilder.Entity<Roles>().HasData(
                new { Role_Id = 1, Role = "Restaurant" },
                new { Role_Id = 2, Role = "User" },
                new { Role_Id = 3, Role = "Delivery" });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
