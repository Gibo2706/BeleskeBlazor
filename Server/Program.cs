using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Server.Repositoriums;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<BeleskaRepo>();
builder.Services.AddScoped<CasRepo>();
builder.Services.AddScoped<PredmetRepo>();
builder.Services.AddScoped<SemestarRepo>();
builder.Services.AddScoped<StudentRepo>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{ 
    options.IdleTimeout = TimeSpan.FromSeconds(300);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
