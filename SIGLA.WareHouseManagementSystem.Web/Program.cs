using AspnetCoreMvcFull.Data;
using AspnetCoreMvcFull.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SIGLA.WareHouseManagementSystem.Web.Configuration;
using SIGLA.WareHouseManagementSystem.Web.HelpersEntity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"./keys/"))
    .SetApplicationName("MiPresuApp");





//builder.Services.AddControllersWithViews()
//    .AddRazorRuntimeCompilation();


builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation()
    .AddJsonOptions(options =>
    {
      options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });



builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();




// 🔧 Registra el DbContext aquí
builder.Services.AddDbContext<AspnetCoreMvcFullContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AspnetCoreMvcFullContext")));


builder.Services.AddAuthentication("MyCookieAuth")
    .AddCookie("MyCookieAuth", options =>
    {
      options.Cookie.Name = "MiCookieLogin";
      options.LoginPath = "/Auth/LoginBasic";
      options.ExpireTimeSpan = TimeSpan.FromDays(180); // duración 6 meses
      //options.ExpireTimeSpan = TimeSpan.FromSeconds(5);

      //options.SlidingExpiration = true; // se renueva si el usuario está activo
      options.SlidingExpiration = false; // se renueva si el usuario está activo
    });

builder.Services.AddControllersWithViews(options =>
{
  options.Filters.Add<ViewBagSessionFilter>();
});



 



// Registra tus servicios personalizados
DependencyInjectionConfig.RegisterServices(builder.Services, builder.Configuration);

// Registra la sesión
//builder.Services.AddSession();

builder.Services.AddSession(options =>
{
  options.IdleTimeout = TimeSpan.FromDays(7); // ⏱ 1 semana
  //options.IdleTimeout = TimeSpan.FromSeconds(3);

  options.Cookie.HttpOnly = true;
  options.Cookie.IsEssential = true;
});


// 🔨 Crea la aplicación (después de registrar todo)
var app = builder.Build();

// 🧠 Habilita el middleware de sesión (después de `app = builder.Build()`)
app.UseSession();

// 🌱 Inicialización de datos de prueba
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  SeedData.Initialize(services);
}

// 🛠️ Middleware estándar
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // 🔐 ¡Importante!

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboards}/{action=Index}/{id?}");

app.Run();
