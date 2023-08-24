using ArticleWebSite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

#region DBContext

var configuration = builder.Configuration;
builder.Services.AddDbContext<ArticleContext>(options =>
{
    //options.UseSqlServer(configuration["ConnectionStrings:EfCore"]);
    options.UseSqlServer(configuration.GetConnectionString("Article_WebSite"));
});

#endregion

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
