using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Core.Entities.Concrete;
using Core.Utilities.SendMail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Customer
builder.Services.AddSingleton<ICustomerService, CustomerManager>();
builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();




//Send Mail
builder.Services.AddSingleton<ISendMailHelper, SendMailHelper>();
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
//User
builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IUserDal, EfUserDal>();
//Auth Service
builder.Services.AddSingleton<IAuthService, AuthManager>();
//HashingHelper
builder.Services.AddSingleton<HashingHelper>();
//JwtHelper
builder.Services.AddSingleton<JwtHelper>();
//JwtSettings
builder.Services.AddSingleton<JwtSettings>();
//OperationClaims Default
builder.Services.AddSingleton<IOperationClaimService, OperationClaimManager>();
builder.Services.AddSingleton<IOperationClaimDal, EfOperationClaimDal>();
builder.Services.AddSingleton<IUserOperationClaimService, UserOperationClaimManager>();
builder.Services.AddSingleton<IUserOperationClaimDal, EfUserOperationClaimDal>();

//FluentVAlidatoin
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

//Jwt setting
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty))
    };
});
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

//

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
