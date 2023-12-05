using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TBSExam.Business.Scripts;
using TBSExam.Data.ExamContext;
using TBSExam.Data.Repositories.Interfaz;
using TBSExam.Data.Repositories.Repository;
using TBSExam.Service.Interfaces;
using TBSExam.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services
    .AddRazorPages()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddScoped<IBitacoraService, BitacoraService>();
builder.Services.AddScoped<IFolioService, FolioService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ISaveService, SaveService>();
builder.Services.AddScoped<GenerarFolios>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddSession();

builder.Services.AddDbContext<ExamContextConnection>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
