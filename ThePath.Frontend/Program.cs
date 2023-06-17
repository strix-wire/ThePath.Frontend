using ThePath.Frontend.Services.Classes;
using ThePath.Frontend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ISendMailToAurhorEmail, SendMailToAurhorEmail>();
builder.Services.AddHttpClient<IEntertainmentService, EntertainmentService>();

var app = builder.Build();

//Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = ctx =>
    {
        //cash on time 10 min
        ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
    }
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
