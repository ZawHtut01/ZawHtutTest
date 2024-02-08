using Microsoft.EntityFrameworkCore;
using ZawHtutTest.Database;
using IronPdf;

var Renderer = new ChromePdfRenderer();
// Create a PDF from a URL or local file path
using var pdf = Renderer.RenderUrlAsPdf("https://www.amazon.com/?tag=hp2-brobookmark-us-20");
// Export to a file or Stream
pdf.SaveAs("url.pdf");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
