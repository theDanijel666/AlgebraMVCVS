var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "moja-ruta",
    pattern:"{language=hr}/Pocetna",
    defaults: new { controller="Osobe", action="Index" }
    );

app.MapControllerRoute(
    name: "onemoguci-osobe-controller",
    pattern: "Jocker",
    defaults: new { controller = "Osobe", action = "Index",id=1 }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "onemoguci-osobe-controller",
    pattern: "Osobe/{action=Index}/{id?}",
    defaults: new { controller = "Home", action = "Index" }
    );


app.Run();
