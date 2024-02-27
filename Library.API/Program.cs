using Library.Application.Commands.CreateBook;
using Library.Application.Commands.CreateLoan;
using Library.Application.Commands.CreateUser;
using Library.Application.Commands.LoanDevolver;
using Library.Application.Queries;
using Library.Application.Queries.GetBookById;
using Library.Application.Queries.GetLoanByIdUser;
using Library.Infra.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var stringConnection = builder.Configuration.GetConnectionString("LibraryDB");

builder.Services.AddDbContext<LibraryContext>(o => o.UseSqlServer(stringConnection));

builder.Services.AddMediatR(typeof(CreateLoanCommand));
builder.Services.AddMediatR(typeof(CreateUserCommand));
builder.Services.AddMediatR(typeof(CreateBookCommand));
builder.Services.AddMediatR(typeof(GetBookByIdQuery));
builder.Services.AddMediatR(typeof(GetLoanByIdQuery));
builder.Services.AddMediatR(typeof(GetLoansByIdUserQuery));
builder.Services.AddMediatR(typeof(CreateLoanCommand));
builder.Services.AddMediatR(typeof(LoanDevolverCommand));

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