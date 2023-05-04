using ClassJournal.Extensions;
using Microsoft.EntityFrameworkCore;
using NLog;
using Repository;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
var connectionString = builder.Configuration.GetConnectionString("sqlConnection");
builder.Services.AddDbContext<RepositoryContext>(x => x.UseSqlServer(connectionString));
//builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddControllers(config => {
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters()
.AddApplicationPart(typeof(GroupStudent.Presentation.AssemblyReference).Assembly);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureCors();
builder.Services.AddControllers();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
var app = builder.Build();


if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
