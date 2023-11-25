using eShop.Models;

namespace eShop.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                // products
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<product>()



                        );
                    context.SaveChanges();

                }
                // stores
                if (!context.Stores.Any())
                {
                    context.Stores.AddRange(new List<Store>() {
                        new Store()
                        {
                            store_Id = 1002,
                            store_Name = "Def_store",
                            store_PinCode = "100445",
                            store_isOpen = "y"
                        }
                    }



                        );
                    context.SaveChanges();

                }

            }
        }
    }
}
