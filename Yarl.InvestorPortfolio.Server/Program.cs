using Microsoft.Extensions.DependencyInjection;
using Yarl.InvestorPortfolio.DataAccess;
using Yarl.InvestorPortfolio.DataAccess.Interfaces;
using Yarl.InvestorPortfolio.Services;
using Yarl.InvestorPortfolio.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    var services = builder.Services;
    services.AddControllers();
    services.AddSingleton<Yarl.InvestorPortfolio.Core.IAppConfiguration>(new AppConfiguration(builder.Configuration));
    services.AddSingleton<DataContext>();

    services.AddSingleton<IInvestorRepository, InvestorRepository>();
    services.AddSingleton<ICommitmentRepository, CommitmentRepository>();
    services.AddSingleton<IInvestorService, InvestorService>();
    services.AddSingleton<ICommitmentService, CommitmentService>();


    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
