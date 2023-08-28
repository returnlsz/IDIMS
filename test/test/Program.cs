using System.Security.Cryptography;
using System.Text;
using Dm;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using test.Service.Config;
using test.Service.Token;
using test.Service.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("X-Pagination"));
}
);

builder.Services.Configure<JWTToken>(builder.Configuration.GetSection("JWTToken"));
builder.Services.AddTransient<IJWTService, JWTService>();

//验证
JWTToken token = new JWTToken();
builder.Configuration.Bind("JWTToken", token);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer
    (options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience=true,
            ValidateLifetime=true,
            ValidateIssuerSigningKey=true,
            ValidAudience=token.Audience,
            ValidIssuer=token.Issuer,
            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.SecurityKey))
        };
    }
    );

//automapper映射
builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));

//配置swagger发送Authorization报文头 
builder.Services.AddSwaggerGen(
    e =>
    {
        var scheme = new OpenApiSecurityScheme()
        {
            Description = "Authorization header.",
            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Authorization" },
            Scheme = "oauth2",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
        };
        e.AddSecurityDefinition("Authorization", scheme);
        var requirement = new OpenApiSecurityRequirement();
        requirement[scheme] = new List<string>();
        e.AddSecurityRequirement(requirement);
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
