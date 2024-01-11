namespace MovieStore.WebApi;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // string connection = Configuration.GetConnectionString("MsSqlConnection");
        // services.AddDbContext<MovieStoreContext>(options => options.UseSqlServer(connection));
        // var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperConfig()));
        //
        // services.AddMediatR(cfg =>
        //     cfg.RegisterServicesFromAssembly(typeof(CreateMovieCommand).GetTypeInfo().Assembly));
        //
        // services.AddControllers().AddFluentValidation(x =>
        //     x.RegisterValidatorsFromAssemblyContaining<MovieValidator>());
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(x => { x.MapControllers(); });
    }
}