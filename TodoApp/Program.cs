using DbAccess.Data;
using DbAccess.Factory;
using TodoApp.ActionFilters;
using TodoData.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddSingleton<IProcedureCaller, DapperProcedureCaller>
    (
        service => new DapperProcedureCaller
        (
            new MySQLConnectionFactory(builder.Configuration.GetConnectionString("Default")
        )
    )
);
builder.Services.AddSingleton<UnitOfWork>();
builder.Services.AddScoped<AuthUserFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
