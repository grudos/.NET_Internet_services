using BlazorServerDbContextExample.Data;
using BlazorServerDbContextExample.Grid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using SportsAgents.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();

builder.Services.AddDbContextFactory<SportsAgentsContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SportsAgentsDB")));

// filters
builder.Services.AddScoped<IAthleteFilters, GridControls>();

// query adapter (applies filter to athlete request).
//builder.Services.AddScoped<GridQueryAdapter>();

// TODO: service to communicate success on edit between pages
builder.Services.AddScoped<EditSuccess>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
