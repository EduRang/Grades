var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Grades.Controllers.SubjectsController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Ruta personalizada para SubjectsController
app.MapControllerRoute(
    name: "subjects",
    pattern: "{controller=Subjects}/{action=Index}/{id?}",
    defaults: new { controller = "Subjects" });

// Ruta personalizada para SubjectsController
app.MapControllerRoute(
    name: "activities",
    pattern: "{controller=Activities}/{action=Index}/{id?}",
    defaults: new { controller = "Activities" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
