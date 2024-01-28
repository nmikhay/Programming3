public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ProductContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    
}
