var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
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
app.UseMvc(routes => {
    routes.MapRoute(
        name: "default",
        template: "{controller=Product}/{action=Index}");
    //routes.MapRoute(
    //   name: "create",
    //   template: "{controller=Product}/{action=Create}");
    //routes.MapRoute(
    //   name: "update",
    //   template: "{controller=Product}/{action=Update}");

    //routes.MapRoute(
    //   name: "delete",
    //   template: "{controller=Product}/{action=Delete}");
});



app.Run();
